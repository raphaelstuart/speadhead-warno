// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

var input = args[0];

var ammo_names = new List<string>()
{
    "Ammo_MMG_AANF1_7_62mm",
    "Ammo_MMG_AANF1_7_62mm_x2",
    "Ammo_MMG_FN_MAG_7_62mm",
    "Ammo_MMG_HK21_7_62mm",
    "Ammo_MMG_L37A2_7_62mm",
    "Ammo_MMG_L43A1_7_62mm",
    "Ammo_MMG_L8A2_7_62mm",
    "Ammo_MMG_L94A1_7_62mm",
    "Ammo_MMG_M1919",
    "Ammo_MMG_M240_7_62mm",
    "Ammo_MMG_M240_abrams_7_62mm",
    "Ammo_MMG_M240d_7_62mm",
    "Ammo_MMG_M60_7_62mm",
    "Ammo_MMG_MG3_7_62mm",
    "Ammo_MMG_PKT_7_62mm",
    "Ammo_MMG_PKT_7_62mm_x2",
    "Ammo_MMG_PKT_7_62mm_x4",
    "Ammo_MMG_SGMB_7_62mm",
    "Ammo_MMG_UK_vz59_7_62mm",
    "Ammo_MMG_Type59_Tank_7_62mm",
    "Ammo_MMG_Type80_Tank_7_62mm",
};

var wep_names_reg = new List<Regex>();
foreach (var ammo in ammo_names)
{
    wep_names_reg.Add(new Regex(@$"(\s+)Ammunition(\s+)=(\s+)\$\/GFX\/Weapon\/{ammo}") );
}

var lines = File.ReadAllLines(input);
var reg_wep = new Regex(@"export (.*) is TWeaponManagerModuleDescriptor");
var reg_salvo = new Regex(@"(\s+)Salves(\s+)=(\s+)\[");
var reg_index = new Regex(@"(\s+)SalvoStockIndex(\s+)=(\s+)(\d+)");

var salvo = new List<(int lineNumber, string content)>();
for (var i = 0; i < lines.Length; i++)
{
    var line = lines[i];
    if (reg_wep.IsMatch(line))
    {
        Console.WriteLine("====================================");
        Console.WriteLine($"START: {line}");
        salvo = new();
        continue;
    }    
    
    if (reg_salvo.IsMatch(line))
    {
        while (true)
        {
            line = lines[++i];
            
            if (line.Trim() == "]")
                break;
            
            salvo.Add((i, line));
        }
    }

    foreach (var wep_regex in wep_names_reg)
    {
        if (wep_regex.IsMatch(line))
        {
            Console.WriteLine(line.Trim());

            while (true)
            {
                line = lines[++i];
                if (reg_index.IsMatch(line))
                {
                    var salvo_index = int.Parse(line.Split('=')[^1].Trim());
                    var def = salvo[salvo_index];
                    var number = int.Parse(def.content.Trim().Replace(",", ""));
                    number *= 4;
                    lines[def.lineNumber] = $"        {number},";
                    
                    Console.WriteLine($"Salvo[{salvo_index}] = {number}");
                    break;
                }
            }
            break;
        }
    }
}
File.WriteAllLines(input, lines);