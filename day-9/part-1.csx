using System.Linq;

string input = System.IO.File.ReadAllText("input.txt");
int w = input.IndexOf('\n'); // width
string map = input.Replace("\n", "");

WriteLine(map
	.Where((h, i)
		=> (i % w == 0          || h < map[i - 1])
		&& (i % w == w - 1      || h < map[i + 1])
		&& (i - w <  0          || h < map[i - w])
		&& (i + w >= map.Length || h < map[i + w])
	).Select(h => h - '0' + 1)
	.Sum());
