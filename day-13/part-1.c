#include <stdio.h>
#include <stdlib.h>

#define N 750

typedef struct {
	int x;
	int y;
} Point;

int main() {
	int i, j, fold, duplicates = 0;
	char direction;
	Point points[N];
	FILE* input = fopen("input.txt", "r");
	
	for (i = 0; i < N; i++) {
		fscanf(input, "%d,%d", &points[i].x, &points[i].y);
	}
	
	fscanf(input, " fold along %c=%d", &direction, &fold);
	
	if (direction == 'x') {
		for (i = 0; i < N; i++) {
			if (points[i].x > fold) {
				points[i].x = 2 * fold - points[i].x;
			}
		}
	} else {
		for (i = 0; i < N; i++) {
			if (points[i].y > fold) {
				points[i].y = 2 * fold - points[i].y;
			}
		}
	}
	
	for (i = 0; i < N - 1; i++) {
		for (j = i + 1; j < N; j++) {
			if (points[i].x	>= 0 && points[j].x >= 0
				&& points[i].x == points[j].x
				&& points[i].y == points[j].y) {
				duplicates++;
				points[j].x	= -1;
				points[j].y	= -1;
			}
		}
	}
	
	printf("%d\n", N - duplicates);
	
	return 0;
}


