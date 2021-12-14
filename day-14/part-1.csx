string[] input = File.ReadAllText("input.txt").Split("\n\n");
string polymer = input[0];

var rules = input[1]
	.TrimEnd()
	.Split('\n')
	.Select(l => l.Split(" -> "))
	.ToDictionary(l => l[0], l => l[1]);

for (int i = 0; i < 10; i++) {
	for (int j = 0; j < polymer.Length - 1; j++) {
		string pair = polymer.Substring(j, 2);
		
		if (rules.ContainsKey(pair)) {
			polymer = polymer.Insert(j + 1, rules[pair]);
			j++;
		}
	}
}

var counts = polymer
	.GroupBy(c => c)
	.Select(g => g.Count());

WriteLine(counts.Max() - counts.Min());
