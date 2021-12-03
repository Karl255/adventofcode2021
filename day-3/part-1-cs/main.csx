using System.Linq;

var report = System.IO.File.ReadAllLines("../input.txt")
	.SkipLast(1)
	.Select(number => number.Select(b => b == '1' ? 1 : 0))
	.ToArray();

int threshhold = report.Length / 2;

var counts = report
	.Aggregate((x, y) => x
		.Zip(y, (a, b) => (a, b))
		.Select(x => x.a + x.b)
	).ToArray();

int gamma = 0;

for (int i = 0; i < 12; i++) {
	gamma |= (counts[i] > threshhold ? 1 : 0) << (11 - i);
}

System.Console.WriteLine(gamma * (gamma ^ 0xfff));
