// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Text.RegularExpressions;

var all_units_list = new FileInfo(@"..\..\..\..\..\GameData\Generated\Gameplay\Gfx\AllUnitsTactic.ndf");
var regex = args[0]; //@"\$\/GFX\/Unit\/(.*)_BEL"
var output = args[1]; //output dir

var units = File.ReadAllLines(all_units_list.FullName);
var reg = new Regex(regex);
var targets = new List<string>();

foreach (var unit in units)
{
	if (!unit.Trim().StartsWith("$/GFX/Unit/"))
	{
		continue;	
	}

	if (reg.Match(unit).Success)
	{
		targets.Add(unit.Trim()[..^1]);		
	}
}

var pack_names = new List<string>();

var sb_pack = new StringBuilder();
var sb_div_rule = new StringBuilder();
var sb_div = new StringBuilder();
var sb_div_deck = new StringBuilder();

foreach (var tar in targets)
{
	var guid = Guid.NewGuid();
	var tar_name = tar.Trim().Replace("$/GFX/Unit/Descriptor_Unit_", "");
	var pack_name = $"Descriptor_Deck_Pack_TOE_{tar_name}";
	var code = $"""
	           {pack_name} is TDeckPackDescriptor
	           (
	               DescriptorId = GUID:{guid:B}
	               CfgName = 'TOE_{tar_name}'
	               TransporterAndUnitsList =
	               [
	                   TDeckTransporterAndUnitsDescriptor
	                   (
	                       UnitDescriptor = {tar}
	                   ),
	               ]
	           )
	           """;
	pack_names.Add(pack_name);
	sb_pack.AppendLine(code);

	var code2 = $"(~/{pack_name}, 1),";
	sb_div.AppendLine(code2);
	
	var code3 = $"""
				TDeckUniteRule
				(
					UnitDescriptor = {tar}
					AvailableWithoutTransport = True
					AvailableTransportList = []
					NumberOfUnitInPack = 16
					NumberOfUnitInPackXPMultiplier = [1.0, 0.68, 0.34, 0.0]
				),
				""";
	sb_div_rule.AppendLine(code3);

	var code4 = $"""
	             TDeckPackDescription
	             (
	                 ExperienceLevel = 0
	                 DeckPack = ~/{pack_name}
	             ),
	             """;
	sb_div_deck.AppendLine(code4);
}

File.WriteAllText($"{output}\\Gen_DivRule.ndf", sb_div_rule.ToString());
File.WriteAllText($"{output}\\Gen_Div.ndf", sb_div.ToString());
File.WriteAllText($"{output}\\Gen_Packs.ndf", sb_pack.ToString());
File.WriteAllText($"{output}\\Gen_Decks.ndf", sb_div_deck.ToString());