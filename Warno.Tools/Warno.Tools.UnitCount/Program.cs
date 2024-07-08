// See https://aka.ms/new-console-template for more information

var input = args[0];
var output = args[1];
var mul = 2f;

var content = File.ReadAllLines(input);

var target =
"""
$/GFX/Unit/Descriptor_Unit_Mi_24D_AA_DDR,
$/GFX/Unit/Descriptor_Unit_Mi_24D_Desant_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_24D_s5_AT_DDR,
$/GFX/Unit/Descriptor_Unit_Mi_24D_s8_AT_DDR,
$/GFX/Unit/Descriptor_Unit_Mi_24K_reco_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_24P_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_24P_s8_AT2_DDR,
$/GFX/Unit/Descriptor_Unit_Mi_24P_s8_AT_DDR,
$/GFX/Unit/Descriptor_Unit_Mi_24VP_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_24V_AA_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_24V_AT_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_24V_RKT_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_24V_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_26_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_2_reco_DDR,
$/GFX/Unit/Descriptor_Unit_Mi_2_reco_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_2_trans_DDR,
$/GFX/Unit/Descriptor_Unit_Mi_2_trans_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_8K_CMD_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_8MTPI_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_8MTV_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_8R_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_8TB_DDR,
$/GFX/Unit/Descriptor_Unit_Mi_8TV_DDR,
$/GFX/Unit/Descriptor_Unit_Mi_8TV_Gunship_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_8TV_PodGatling_DDR,
$/GFX/Unit/Descriptor_Unit_Mi_8TV_PodGatling_PodAGL_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_8TV_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_8TV_UPK_DDR,
$/GFX/Unit/Descriptor_Unit_Mi_8TV_non_arme_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_8TV_s57_16_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_8TV_s57_32_DDR,
$/GFX/Unit/Descriptor_Unit_Mi_8TV_s57_32_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_8TV_s80_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_8TZ_SOV,
$/GFX/Unit/Descriptor_Unit_Mi_8T_DDR,
$/GFX/Unit/Descriptor_Unit_Mi_8T_non_arme_DDR,
$/GFX/Unit/Descriptor_Unit_Mi_8_supply_DDR,
$/GFX/Unit/Descriptor_Unit_Mi_9_DDR,
$/GFX/Unit/Descriptor_Unit_Ka_50_AA_SOV,
$/GFX/Unit/Descriptor_Unit_Ka_50_SOV,
""";

var targetUnits = target.Split(',').Distinct().ToArray();
targetUnits = Array.ConvertAll(targetUnits, i => i.Trim());

var currentUnit = "";
for (var i = 0; i < content.Length; i++)
{
	var line = content[i];

	if (line.Contains("UnitDescriptor ="))
	{
		var unit_name = line.Split('=')[^1].Trim();
		currentUnit = unit_name;
	}
	
	if (Check(line))
	{
		if (targetUnits.Contains(currentUnit))
		{
			content[i] = DoReplace(line);
		}
	}
}

bool Check(string line) => line.Contains("NumberOfUnitInPack =");

string DoReplace(string line)
{
	// NumberOfUnitInPack = 3
	var spc_count = line.TrimEnd().Count(Char.IsWhiteSpace);
	var unit_count = int.Parse(line.Split('=')[^1]);
	var des = "NumberOfUnitInPack = " + Math.Ceiling(unit_count * mul);

	for (var i = 0; i < spc_count - 2; i++)
	{
		des = " " + des;
	}

	return des;
}

File.WriteAllLines(output, content);