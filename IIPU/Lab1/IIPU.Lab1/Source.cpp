#define _CRT_SECURE_NO_DEPRECATE
#include <stdio.h>
#include <windows.h>
#include <setupapi.h>
#include <regstr.h>
#pragma comment (lib, "Setupapi.lib")

void PrintIds(LPSTR PCIID);
void getDevicesInfo(FILE* file, LPTSTR HID);

int main()
{			
	DWORD dword;
	FILE* in = fopen("pci.ids", "r");
	LPTSTR buffer;
	DWORD buffersize;

	HDEVINFO hDevInfo = SetupDiGetClassDevs(NULL,   
		REGSTR_KEY_PCIENUM,
		0,
		DIGCF_PRESENT | DIGCF_ALLCLASSES);		

	if (hDevInfo == INVALID_HANDLE_VALUE)
	{
		fclose(in);
		return 1;		
	}

	SP_DEVINFO_DATA DeviceInfoData;
	DeviceInfoData.cbSize = sizeof(SP_DEVINFO_DATA);

	for (dword = 0; SetupDiEnumDeviceInfo(hDevInfo, dword, &DeviceInfoData); dword++)	
	{
		buffer = NULL;
		buffersize = 0;				

		while (!SetupDiGetDeviceRegistryProperty(
			hDevInfo,
			&DeviceInfoData,
			SPDRP_HARDWAREID,
			NULL,
			(PBYTE)buffer,
			buffersize,
			&buffersize))

			if (GetLastError() == ERROR_INSUFFICIENT_BUFFER)
			{
				if (buffer)
				{
					LocalFree(buffer);
				}
				buffer = (LPTSTR)LocalAlloc(LPTR, buffersize * 2);
			}
			else
				break;

		PrintIds(buffer);			

		getDevicesInfo(in, buffer);

		if (buffer)
			LocalFree(buffer);
		fseek(in, 0, 0);
	}
	fclose(in);
	if (GetLastError() != NO_ERROR &&
		GetLastError() != ERROR_NO_MORE_ITEMS)
		return 1;
	SetupDiDestroyDeviceInfoList(hDevInfo);
	system("PAUSE");
	return 0;
}

void PrintIds(LPSTR PCIID)
{
	int p = -1;
	while (PCIID[p++])
	{
		printf("%c", PCIID[p]);
	}
	printf("\nVendor ID is: ");

	for (int j = 4, p = 8; j > 0; j--, p++)
	{
		printf("%c", PCIID[p]);
	}
	printf("\nDevice ID is: ");

	for (int j = 4, p = 17; j > 0; j--, p++)
	{
		printf("%c", PCIID[p]);
	}
}

void getDevicesInfo(FILE* file, LPTSTR HID)
{
	char* buffer = (char*)calloc(150, sizeof(char));

	char vendorID[4], deviceID[4];

	for (int j = 0, c = 17, p = 8; j < 4; j++, c++, p++)
	{
		vendorID[j] = towlower(HID[p]);
		deviceID[j] = towlower(HID[c]);
	}

	while (!feof(file))
	{
		fgets(buffer, 150, file);
		if (buffer[0] == '#')
			continue;

		if (vendorID[0] == buffer[0] &&
			vendorID[1] == buffer[1] &&
			vendorID[2] == buffer[2] &&
			vendorID[3] == buffer[3])
		{
			printf("\n");
			puts(buffer);			
			do
			{
				fgets(buffer, 150, file);
				if (buffer[0] == '#')
				{
					buffer[0] = '\t';
					continue;
				}
				else if (buffer[0] == '\t')
				{
					if (deviceID[0] == buffer[1] &&		
						deviceID[1] == buffer[2] &&
						deviceID[2] == buffer[3] &&
						deviceID[3] == buffer[4])
					{
						printf("Device is: ");
						puts(buffer);						
						printf("********************\n");
						do
						{
							fgets(buffer, 150, file);
							if (buffer[0] == '#')
							{
								buffer[0] = '\t';
								buffer[1] = '\t';
								continue;
							}
						} while (buffer[0] == '\t' && buffer[1] == '\t');
					}
				}
			} while (buffer[0] == '\t');
		}
	}
}