int[] dumbos = File.ReadAllText("input.txt").Replace("\n", "").Select(c => c - '0').ToArray();
int steps = 0;
int flashes;

do {
	bool[] flashed = new bool[100];
	flashes = 0;
	steps++;
	
	for (int i = 0; i < dumbos.Length; i++) {
		dumbos[i]++;
	}
	
	for (int i = 0; i < dumbos.Length; i++) {
		if (!flashed[i] && dumbos[i] > 9) {
			Flash(dumbos, flashed, i);
		}
	}
	
	for (int i = 0; i < dumbos.Length; i++) {
		if (flashed[i]) {
			dumbos[i] = 0;
			flashes++;
		}
	}
} while (flashes != 100);

WriteLine(steps);

void Flash(int[] dumbos, bool[] flashed, int index) {
	flashed[index] = true;
	
	int xMin = index % 10 ==   0 ? 0 : -1;
	int xMax = index % 10 ==   9 ? 0 :  1;
	int yMin = index - 10 <    0 ? 0 : -1;
	int yMax = index + 10 >= 100 ? 0 :  1;
	
	for (int y = yMin; y <= yMax; y++) {
		for (int x = xMin; x <= xMax; x++) {
			if (x == 0 && y == 0) {
				continue;
			}
			
			int j = index + y * 10 + x;
			
			dumbos[j]++;
			if (!flashed[j] && dumbos[j] > 9) {
				Flash(dumbos, flashed, j);
			}
		}
	}
}
