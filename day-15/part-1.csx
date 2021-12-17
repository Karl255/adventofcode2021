string[] cave = File.ReadAllLines("input.txt");
int w = cave.Length;
int[,] distances = new int[w, w];
bool[,] visited = new bool[w, w];

for (int y = 0; y < w; y++) {
	for (int x = 0; x < w; x++) {
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
	
	if (x + 1 < w && !visited[x + 1, y]) {
		distances[x + 1, y] = Math.Min(distances[x + 1, y], distances[x, y] + cave[y][x + 1] - '0');
		nodes.Add((x + 1, y));
	}
	
	if (y + 1 < w && !visited[x, y + 1]) {
		distances[x, y + 1] = Math.Min(distances[x, y + 1], distances[x, y] + cave[y + 1][x] - '0');
		nodes.Add((x, y + 1));
	}
	
	if (x - 1 >= 0 && !visited[x - 1, y]) {
		distances[x - 1, y] = Math.Min(distances[x - 1, y], distances[x, y] + cave[y][x - 1] - '0');
		nodes.Add((x - 1, y));
	}
	
	if (y - 1 >= 0 && !visited[x, y - 1]) {
		distances[x, y - 1] = Math.Min(distances[x, y - 1], distances[x, y] + cave[y - 1][x] - '0');
		nodes.Add((x, y - 1));
	}
	
	visited[x, y] = true;
}

WriteLine(distances[w - 1, w - 1]);
