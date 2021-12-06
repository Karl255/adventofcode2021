#include <stdio.h>

int main() {
	size_t t, i, j, ages[9] = { 0 }, sum = 0;
	FILE* input = fopen("input.txt", "r");
	
	do {
		fscanf(input, "%zd", &t);
		
		ages[t]++;
	} while (fgetc(input) == ',');
	
	fclose(input);
	
	for (i = 0; i < 256; i++) {
		ages[(i + 7) % 9] += ages[i % 9];
	}
	
	for (i = 0; i < 9; i++) {
		sum += ages[i];
	}
	
	printf("%zd\n", sum);
	
	return 0;
}
