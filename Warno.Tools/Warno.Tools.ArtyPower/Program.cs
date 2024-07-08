// See https://aka.ms/new-console-template for more information

var input = args[0];
var output = args[1];

var lines = File.ReadAllLines(input);

var damageMul = 2f;
var suppressionMul = 3f;

for (var i = 0; i < lines.Length; i++)
{
	var line = lines[i];
	if (line.Trim().StartsWith("PhysicalDamages"))
	{
		var str = line.Split('=');
		var val = float.Parse(str[^1].Trim());
		val *= damageMul;
		lines[i] = $"    PhysicalDamages                   = {val}";
	}
	
	if (line.Trim().StartsWith("SuppressDamages"))
	{
		var str = line.Split('=');
		var val = float.Parse(str[^1].Trim());
		val *= suppressionMul;
		lines[i] = $"    SuppressDamages                   = {val}";
	}
}

File.WriteAllLines(output, lines);