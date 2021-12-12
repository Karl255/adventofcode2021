(string a, string b)[] links = File
	.ReadAllLines("input.txt")
	.Select(line => (line.Split('-')[0], line.Split('-')[1]))
	.ToArray();

string[] allCaves = links
	.SelectMany(link => new string[] { link.a, link.b })
	.Distinct()
	.ToArray();

int nSmall = allCaves.Count(c => char.IsLower(c[0]));
int iSmall = 0;
int iBig = 0;

Dictionary<string, int> nameMap = new(allCaves.Length);

foreach (var cave in allCaves) {
	if (cave == "start") {
		nameMap.Add(cave, 0);
	} else if (cave == "end") {
		nameMap.Add(cave, 1);
	} else if (char.IsLower(cave[0])) {
		nameMap.Add(cave, 2 + iSmall++);
	} else {
		nameMap.Add(cave, nSmall + iBig++);
	}
}

int n = allCaves.Length;
bool[,] adjacencyMatrix = new bool[n, n];

foreach (var (a, b) in links) {
	int i = nameMap[a];
	int j = nameMap[b];
	adjacencyMatrix[i, j] = true;
	adjacencyMatrix[j, i] = true;
}

bool[] visited = new bool[nSmall];
visited[0] = true;
WriteLine(PathsToEnd(n, adjacencyMatrix, nSmall, 0, visited));

int PathsToEnd(int n, bool[,] adjacency, int nSmall, int from, bool[] visited) {
	int paths = 0;
	
	for (int i = 0; i < n; i++) {
		if (i == from || !adjacencyMatrix[from, i]) continue;
		
		if (i == 1) {
			paths++;
			continue;
		}
		
		if (i < nSmall) {
			if (visited[i]) continue;
			visited[i] = true;
			
			paths += PathsToEnd(n, adjacency, nSmall, i, visited);
			
			visited[i] = false;
		} else {
			paths += PathsToEnd(n, adjacency, nSmall, i, visited);
		}
	}
	
	return paths;
}
