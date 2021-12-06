#include <stdio.h>

int main() {
	size_t t, i, j, ages[9] = { 0 }, sum = 0;
	FILE* input = fopen("input.txt", "r");
	
	do {
		fscanf(input, "%zd", &t);
		
		ages[t]++;
	} while (fgetc(input) == ',');
	
	fclose(input);
	
	for (i = 0; i < 80; i++) {
		t = ages[0];
		
		for (j = 1; j < 9; j++) {
			ages[j - 1] = ages[j];
		}
		
		ages[8] = t;
		ages[6] += t;
	}
	
	for (i = 0; i < 9; i++) {
		sum += ages[i];
	}
	
	printf("%zd\n", sum);
	
	return 0;
}
