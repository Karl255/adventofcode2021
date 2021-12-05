#include <stdio.h>
#include <stdlib.h>

void swap(int* a, int* b) {
	int t = *a;
	*a = *b;
	*b = t;
}

int main() {
	int i, x1, y1, x2, y2, inc, n = 0;
	unsigned char* field;
	FILE* input = fopen("input.txt", "r");
	
	field = calloc(1000 * 1000, sizeof(unsigned char));
	
	while (!feof(input)) {
		fscanf(input, "%d,%d -> %d,%d ", &x1, &y1, &x2, &y2);
		
		if (x1 == x2) { // vertical
			if (y1 > y2) {
				swap(&y1, &y2);
			}
			
			for (i = y1; i <= y2; i++) {
				field[i * 1000 + x1]++;
			}
		} else if (y1 == y2) { // horizontal
			if (x1 > x2) {
				swap(&x1, &x2);
			}
			
			for (i = x1; i <= x2; i++) {
				field[y1 * 1000 + i]++;
			}
		} else { // diagonal
			if (x1 > x2) {
				swap(&x1, &x2);
				swap(&y1, &y2);
			}
			
			inc = y1 < y2 ? 1 : -1;
			
			for (i = 0; i <= x2 - x1; i++) {
				field[(y1 + i * inc) * 1000 + x1 + i]++;
			}
		}
	}
	
	for (i = 0; i < 1000 * 1000; i++) {
		if (field[i] > 1) {
			n++;
		}
	}
	
	printf("%d\n", n);
	
	return 0;
}
