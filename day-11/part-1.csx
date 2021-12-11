int[] dumbos = File.ReadAllText("input.txt").Replace("\n", "").Select(c => c - '0').ToArray();
int flashes = 0;

for (int step = 0; step < 100; step++) {
	bool[] flashed = new bool[100];
	
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
}

WriteLine(flashes);

int Flash(int[] dumbos, bool[] flashed, int index) {
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
	
	return 0;
}
