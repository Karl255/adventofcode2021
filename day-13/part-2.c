#include <stdio.h>
#include <stdlib.h>

#define N 750

typedef struct {
	int x;
	int y;
} Point;

int main() {
	int i, j, k, fold, width, height, hasDot;
	char direction;
	Point points[N];
	FILE* input = fopen("input.txt", "r");
	
	for (i = 0; i < N; i++) {
		fscanf(input, "%d,%d", &points[i].x, &points[i].y);
	}
	
	do {
		fscanf(input, " fold along %c=%d\n", &direction, &fold);
		
		if (direction == 'x') {
			width = fold;
			for (i = 0; i < N; i++) {
				if (points[i].x > fold) {
					points[i].x = 2 * fold - points[i].x;
				}
			}
		} else {
			height = fold;
			for (i = 0; i < N; i++) {
				if (points[i].y > fold) {
					points[i].y = 2 * fold - points[i].y;
				}
			}
		}
	} while (!feof(input));
	
	for (i = 0; i < height; i++) {
		for (j = 0; j < width; j++) {
			hasDot = 0;
			
			for (k = 0; k < N; k++) {
				if (points[k].x	== j && points[k].y == i) {
					hasDot = 1;
					break;
				}
			}
			
			printf(hasDot ? "#" : ".");
		}
		
		printf("\n");
	}
	
	return 0;
}


