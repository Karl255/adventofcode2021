#include <stdio.h>
#include <stdlib.h>

typedef struct {
	size_t length;
	
	unsigned char* data;
	size_t byteIndex;
	
	unsigned char buffer;
	size_t bitIndex : 3;
} Stream;

Stream* readInput();
size_t parsePacket(Stream*);
size_t parseOperator(Stream*, size_t, size_t);
long Stream_readBits(Stream*, size_t);

int main() {
	Stream* input;
	
	printf("%zu\n", parsePacket(input = readInput()));
	
	free(input->data);
	free(input);
	
	return 0;
}

Stream* readInput() {
	int i;
	Stream* input = malloc(sizeof(Stream));
	
	FILE* file = fopen("input.txt", "r");
	fseek(file, 0, SEEK_END);
	input->length = (ftell(file) - 1) >> 1;
	fseek(file, 0, SEEK_SET);
	
	input->data = malloc(input->length * sizeof(unsigned char));
	
	for (i = 0; i < input->length; i++) {
		fscanf(file, "%2hhX", &input->data[i]);
	}
	
	input->byteIndex = 0;
	input->bitIndex = 0;
	
	fclose(file);
	
	return input;
}

size_t parsePacket(Stream* stream) {
	size_t version = Stream_readBits(stream, 3);
	size_t type = Stream_readBits(stream, 3);
	long payload = 0, t;
	
	if (type == 4) {
		do {
			t = Stream_readBits(stream, 5);
			payload = (payload << 4) | (t & 15);
		} while (t & 16);
		
		return version;
	} else {
		return version + parseOperator(stream, version, type);
	}
}

size_t parseOperator(Stream* stream, size_t version, size_t type) {
	unsigned char lengthType = Stream_readBits(stream, 1);
	int length = Stream_readBits(stream, lengthType ? 11 : 15);
	int beginning = (stream->byteIndex << 3) | (stream->bitIndex);
	int n = 0;
	
	size_t versionSum = 0;
	
	while (lengthType == 0
		? (((stream->byteIndex << 3) | (stream->bitIndex)) < beginning + length)
		: (n < length)
	) {
		versionSum += parsePacket(stream);
		n++;
	}
	
	return versionSum;
}

long Stream_readBits(Stream* stream, size_t n) {
	long bits = 0;
	size_t i;
	
	for (i = 0; i < n ; i++) {
		if (stream->bitIndex == 0) {
			stream->buffer = stream->data[stream->byteIndex++];
		}
		
		bits <<= 1;
		bits |= stream->buffer >> 7;
		stream->buffer <<= 1;
		stream->bitIndex++;
	}
	
	return bits;
}
