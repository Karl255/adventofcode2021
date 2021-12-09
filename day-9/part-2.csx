string input = File.ReadAllText("input.txt");
int w = input.IndexOf('\n');
char[] map = input.Replace("\n", "").ToCharArray();

int[] basins = map
	.Select((h, i) => (h, i))
	.Where(x
		=> (x.i % w == 0          || x.h < map[x.i - 1])
		&& (x.i % w == w - 1      || x.h < map[x.i + 1])
		&& (x.i - w <  0          || x.h < map[x.i - w])
		&& (x.i + w >= map.Length || x.h < map[x.i + w])
	).Select(x => Count(x.i))
	.OrderBy(x => -x)
	.ToArray();

WriteLine(basins[0] * basins[1] * basins[2]);

int Count(int i) {
	map[i] = '9';
	return 1
		+ (i % w == 0          || map[i - 1] == '9' ? 0 : Count(i - 1))
		+ (i % w == w - 1      || map[i + 1] == '9' ? 0 : Count(i + 1))
		+ (i - w <  0          || map[i - w] == '9' ? 0 : Count(i - w))
		+ (i + w >= map.Length || map[i + w] == '9' ? 0 : Count(i + w));
}
