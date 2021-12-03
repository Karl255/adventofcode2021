using System.Linq;

var report = System.IO.File.ReadAllLines("../input.txt")
	.SkipLast(1)
	.Select(x => Convert.ToInt32(x, 2))
	.ToArray();

var more = report;
int i = 11;

while (more.Count() > 1) {
	int ones = more.Count(x => (x & (1 << i)) != 0);
	int filter = ones >= more.Count() - ones ? 1 : 0;
	
	more = more
		.Where(x => ((x >> i) & 1) == filter)
		.ToArray();
	
	i--;
}

var less = report;
i = 11;

while (less.Count() > 1) {
	int ones = less.Count(x => (x & (1 << i)) != 0);
	int filter = ones < less.Count() - ones ? 1 : 0;
	
	less = less
		.Where(x => ((x >> i) & 1) == filter)
		.ToArray();
	
	i--;
}

System.Console.WriteLine(more.First() * less.First());
