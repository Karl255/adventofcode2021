int[] depths = System.IO.File
	.ReadAllText("input.txt")
	.Split('\n')
	.Select(int.Parse)
	.ToArray();

WriteLine(depths
	.Skip(3)
	.Select((x, i) => x > depths[i])
	.Count(x => x));
