int[] depths = File
	.ReadAllText("input.txt")
	.Split('\n')
	.Select(int.Parse)
	.ToArray();

WriteLine(depths
	.Skip(1)
	.Select((x, i) => x > depths[i])
	.Count(x => x));
