using System;
using System.Linq;

var depths = System.IO.File
	.ReadAllText("input.txt")
	.Split('\n')
	.Select(int.Parse)
	.ToArray();

System.Console.WriteLine(depths
	.Skip(1)
	.Select((x, i) => x > depths[i])
	.Count(x => x));
