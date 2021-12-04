#include <stdio.h>

struct {
	int x;
	int z;
	int aim;
} submarine;

int main() {
	FILE* input;
	char c;
	int t;
	
	input = fopen("input.txt", "r");
	
	while (1) {
		c = fgetc(input);
		
		if (c == 'f') {
			fseek(input, 7, SEEK_CUR);
			fscanf(input, "%d", &t);
			submarine.x += t;
			submarine.z += t * submarine.aim;
		} else if (c == 'u') {
			fseek(input, 2, SEEK_CUR);
			fscanf(input, "%d", &t);
			submarine.aim -= t;
		} else if (c == 'd') {
			fseek(input, 4, SEEK_CUR);
			fscanf(input, "%d", &t);
			submarine.aim += t;
		} else {
			break;
		}
		
		fseek(input, 1, SEEK_CUR);
	}
	
	fclose(input);
	printf("%d\n", submarine.x * submarine.z);
	
	return 0;
}
