// NOTE: this doesn't work (idk why)
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
unsigned long parsePacket(Stream*);
unsigned long parseArithmetic(Stream*, size_t, size_t);
unsigned long parseLogic(Stream*, size_t, size_t);
unsigned long Stream_readBits(Stream*, size_t);

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

unsigned long min(unsigned long a, unsigned long b) { return a < b ? a : b; }
unsigned long max(unsigned long a, unsigned long b) { return a > b ? a : b; }

unsigned long parsePacket(Stream* stream) {
	size_t version = Stream_readBits(stream, 3);
	size_t type = Stream_readBits(stream, 3);
	unsigned long payload = 0, t;
	
	if (type == 4) {
		do {
			t = Stream_readBits(stream, 5);
			payload = (payload << 4) | (t & 0xf);
		} while (t & 0x10);
		
		return payload;
	} else if (type < 4) {
		return parseArithmetic(stream, version, type);
	} else {
		return parseLogic(stream, version, type);
	}
}

unsigned long parseArithmetic(Stream* stream, size_t version, size_t type) {
	unsigned char lengthType = Stream_readBits(stream, 1);
	int length = Stream_readBits(stream, lengthType ? 11 : 15);
	int beginning = (stream->byteIndex << 3) | (stream->bitIndex);
	int n = 0;
	
	unsigned long aggregate, value;
	
	while (lengthType == 0
		? (((stream->byteIndex << 3) | (stream->bitIndex)) < beginning + length)
		: (n < length)) {
		
		value = parsePacket(stream);
		
		if (n == 0) {
			aggregate = value;
		} else {
			switch (type) {
				case 0: aggregate += value; break; // +
				case 1: aggregate *= value; break; // *
				case 2: aggregate = min(aggregate, value); break; // min
				case 3: aggregate = max(aggregate, value); break; // max
			}
		}
		
		n++;
	}
	
	return aggregate;
}

unsigned long parseLogic(Stream* stream, size_t version, size_t type) {
	unsigned char lengthType = Stream_readBits(stream, 1);
	int length = Stream_readBits(stream, lengthType ? 11 : 15);
	
	unsigned long packetA = parsePacket(stream);
	unsigned long packetB = parsePacket(stream);
	
	switch (type) {
		case 5: return packetA >  packetB;
		case 6: return packetA <  packetB;
		case 7: return packetA == packetB;
	}
}

unsigned long Stream_readBits(Stream* stream, size_t n) {
	unsigned long bits = 0;
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
