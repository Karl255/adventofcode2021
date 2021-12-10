string[] lines = File.ReadAllLines("input.txt");
int score = 0;

foreach (var line in lines) {
	Stack<char> stack = new(128);
	for (int i = 0; i < line.Length; i++) {
		if ("([{<".Contains(line[i])) {
			stack.Push(line[i]);
		} else {
			if ((stack.Pop() | 7) != (line[i] | 7)) {
				score += line[i] switch {
					')' => 3,
					']' => 57,
					'}' => 1197,
					'>' => 25137,
					_ => 0
				};
				
				break;
			}
		}
	}
}

WriteLine(score);
