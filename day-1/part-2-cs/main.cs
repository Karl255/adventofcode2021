using System;
using System.Linq;

var depths = System.IO.File.ReadAllText("../input.txt").Split("\n").Select(int.Parse).ToArray();
int count = 0;

for (int i = 3; i < depths.Length; i++) {
	if (depths[i - 3] < depths[i]) {
		count++;
	}
}

System.Console.WriteLine(count);
