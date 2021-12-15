string[] cave = File.ReadAllLines("input.txt");
int[,] distances = new int[cave[0].Length, cave.Length];
int w = cave.Length;

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

WriteLine(distances[w - 1, w - 1]);

int DistanceFor(string[] cave, int[,] distances, int x, int y) {
	int top  = y > 0 ? distances[x, y - 1] + cave[y][x] - '0' : int.MaxValue;
	int left = x > 0 ? distances[x - 1, y] + cave[y][x] - '0' : int.MaxValue;

	return top < left ? top : left;
}