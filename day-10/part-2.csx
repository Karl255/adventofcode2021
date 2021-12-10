string[] lines = File.ReadAllLines("input.txt");
long[] scores = new long[lines.Length];
int i = 0;

foreach (var line in lines) {
	Stack<char> stack = new(128);
	bool corrupted = false;
	
	for (int i = 0; i < line.Length; i++) {
		if ("([{<".Contains(line[i])) {
			stack.Push(line[i]);
		} else {
			if ((stack.Pop() | 7) != (line[i] | 7)) {
				corrupted = true;
				break;
			}
		}
	}
	
	if (!corrupted) {
		scores[i++] = stack.Aggregate(0L, (t, v) => 5L * t + (v switch {
			'(' => 1L,
			'[' => 2L,
			'{' => 3L,
			'<' => 4L,
			_   => 0L
		}));
	}
}

WriteLine(scores.Take(i).OrderBy(x => x).ToArray()[i / 2]);
