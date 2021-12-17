string[] cave = File.ReadAllLines("input.txt");
int w = cave.Length;
int[,] distances = new int[5 * w, 5 * w];
bool[,] visited = new bool[5 * w, 5 * w];

for (int y = 0; y < 5 * w; y++) {
	for (int x = 0; x < 5 * w; x++) {
		distances[x, y] = int.MaxValue;
	}
}

distances[0, 0] = 0;

var nodes = new HashSet<(int x, int y)>();

nodes.Add(new(0, 0));

while (nodes.Count > 0) {
	var node = nodes.OrderBy(a => distances[a.x, a.y]).First();
	var (x, y) = node;
	
	nodes.Remove(node);
	
	if (x + 1 < 5 * w && !visited[x + 1, y]) {
		distances[x + 1, y] = Math.Min(distances[x + 1, y], distances[x, y] + ReadCave(cave, x + 1, y));
		nodes.Add((x + 1, y));
	}
	
	if (y + 1 < 5 * w && !visited[x, y + 1]) {
		distances[x, y + 1] = Math.Min(distances[x, y + 1], distances[x, y] + ReadCave(cave, x, y + 1));
		nodes.Add((x, y + 1));
	}
	
	if (x - 1 >= 0 && !visited[x - 1, y]) {
		distances[x - 1, y] = Math.Min(distances[x - 1, y], distances[x, y] + ReadCave(cave, x - 1, y));
		nodes.Add((x - 1, y));
	}
	
	if (y - 1 >= 0 && !visited[x, y - 1]) {
		distances[x, y - 1] = Math.Min(distances[x, y - 1], distances[x, y] + ReadCave(cave, x, y - 1));
		nodes.Add((x, y - 1));
	}
	
	visited[x, y] = true;
}

WriteLine(distances[5 * w - 1, 5 * w - 1]);

int ReadCave(string[] cave, int x, int y) {
	int w = cave.Length;
	int t = cave[y % w][x % w] - '0' + x / w + y / w;
	return t > 9 ? t - 9 : t;
}
