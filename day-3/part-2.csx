using System.Linq;

var report = File.ReadAllLines("input.txt")
	//.SkipLast(1)
	.Select(x => Convert.ToInt32(x, 2))
	.ToArray();

var more = report;

for (int i = 11; i >= 0; i--) {
	int ones = more.Count(x => (x & (1 << i)) != 0);
	int filter = ones >= more.Length - ones ? 1 : 0;
	
	more = more
		.Where(x => ((x >> i) & 1) == filter)
		.ToArray();
}

var less = report;

for (int i = 11; i >= 0; i--) {
	int ones = less.Count(x => (x & (1 << i)) != 0);
	int filter = ones < less.Length - ones ? 1 : 0;
	
	less = less
		.Where(x => ((x >> i) & 1) == filter)
		.ToArray();
	
	i--;
}

WriteLine(more[0] * less[0]);
