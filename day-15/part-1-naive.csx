string[] cave = File.ReadAllLines("input.txt");
int w = cave.Length;
int[,] distances = new int[w, w];

distances[0, 0] = 0;

for (int i = 1; i < w; i++) {
	for (int j = 0; j < i + 1; j++) {
		distances[i - j, j] = DistanceFor(cave, distances, i - j, j);
	}
}

for (int i = 1; i < w; i++) {
	for (int j = 0; j < w - i; j++) {
		distances[w - 1 - j, i + j] = DistanceFor(cave, distances, w - 1 - j, i + j);
	}
}

for (int y = 0; y < w; y++) {
	for (int x = 0; x < w; x++) {
		Write($"{distances[x, y],4}");
	}
	
	WriteLine();
}

WriteLine(distances[w - 1, w - 1]);

int DistanceFor(string[] cave, int[,] distances, int x, int y) {
	int top  = y > 0 ? distances[x, y - 1] : int.MaxValue;
	int left = x > 0 ? distances[x - 1, y] : int.MaxValue;

	return (top < left ? top : left) + cave[y][x] - '0';
}
