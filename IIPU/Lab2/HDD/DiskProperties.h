#pragma once

class DiskProperties
{
public:
	static const int MaxSize = 16;
	int dma[MaxSize], pio[MaxSize];
	int totalSpace;
	int freeSpace;
	char* Version;
	char* Id;
	char* Revision;
	char* Bus;
	char* SerialNumber;

	static void setSupportMode(unsigned short supported, int* support)
	{
		int i = MaxSize;
		while (i--) {
			support[i] = supported & 32768? 1 : 0;
			supported <<= 1;
		}
	}
};