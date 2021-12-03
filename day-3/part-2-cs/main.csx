using System.Linq;

var report = File.ReadAllLines("../input.txt")
	.SkipLast(1)
	.Select(x => Convert.ToInt32(x, 2))
	.ToArray();

var more = report;
int i = 11;

while (more.Length > 1) {
	int ones = more.Count(x => (x & (1 << i)) != 0);
	int filter = ones >= more.Length - ones ? 1 : 0;
	
	more = more
		.Where(x => ((x >> i) & 1) == filter)
		.ToArray();
	
	i--;
}

var less = report;
i = 11;

while (less.Length > 1) {
	int ones = less.Count(x => (x & (1 << i)) != 0);
	int filter = ones < less.Length - ones ? 1 : 0;
	
	less = less
		.Where(x => ((x >> i) & 1) == filter)
		.ToArray();
	
	i--;
}

WriteLine(more[0] * less[0]);
