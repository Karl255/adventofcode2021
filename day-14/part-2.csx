string[] input = File.ReadAllText("input.txt")
	.Split("\n\n");

var polymer = Enumerable
	.Range(0, input[0].Length - 1)
	.Select(i => (l: input[0][i], r: input[0][i + 1]))
	.GroupBy(p => p)
	.Select(g => (key: g.Key, value: g.LongCount()))
	.ToDictionary(
		x => x.key,
		x => x.value
	);

Dictionary<(char, char), char> rules = input[1]
	.TrimEnd()
	.Split('\n')
	.Select(l => l.Split(" -> "))
	.ToDictionary(l => (l[0][0], l[0][1]), l => l[1][0]);

for (int i = 0; i < 40; i++) {
	Dictionary<(char, char), long> newPolymer = new();
	
	foreach (var (pair, count) in polymer) {
		var newPair = pair with { l = rules[pair] };
		newPolymer[newPair] = (newPolymer.ContainsKey(newPair) ? newPolymer[newPair] : 0L) + polymer[pair];
		
		newPair = pair with { r = rules[pair] };
		newPolymer[newPair] = (newPolymer.ContainsKey(newPair) ? newPolymer[newPair] : 0L) + polymer[pair];
	}
	
	polymer = newPolymer;
}

var counts = polymer
	.Select(kvPair => (element: kvPair.Key.r, count: kvPair.Value))
	.Append((input[0][0], 1))
	.GroupBy(pair => pair.element, pair => pair.count)
	.Select(g => g.Sum());

WriteLine(counts.Max() - counts.Min());
