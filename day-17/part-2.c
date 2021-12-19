#include <stdio.h>
#include <stdlib.h>

int simulate(int, int, int, int, int, int);

int main() {
	int x, y, n = 0, target_minX, target_maxX, target_minY, target_maxY, t;
	
	FILE* input = fopen("input.txt", "r");
	fscanf(input, "target area: x=%d..%d, y=%d..%d", &target_minX, &target_maxX, &target_minY, &target_maxY);
	fclose(input);
	
	for (y = 500; y >= target_minY; y--) {
		for (x = 1; x <= target_maxX; x++) {
			if (simulate(x, y, target_minX, target_maxX, target_minY, target_maxY)) {
				n++;
			}
		}
	}
	
	printf("%d\n", n);
	
	return 0;
}

int simulate(int v_x, int v_y, int t_minX, int t_maxX, int t_minY, int t_maxY) {
	int x = 0, y = 0, maxY = 0;
	
	while ((x < t_minX || y > t_maxY) && y >= t_minY) {
		x += v_x;
		y += v_y;
		
		if (v_x > 0) {
			v_x--;
		}
		
		v_y--;
	}
	
	return x <= t_maxX && y >= t_minY ? 1 : 0;
}
