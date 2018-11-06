#define _CRT_SECURE_NO_WARNINGS
#define _UNICODE
#define UNICODE
#include <Windows.h>
#include <tchar.h> 

using namespace std;

int main(int argc, char**argv)
{
	HWND WindowHandler = GetConsoleWindow();
	ShowWindow(WindowHandler, 0);

	TCHAR devicepath[16];

	_tcscpy(devicepath, _T("\\\\.\\?:"));
	devicepath[4] = argv[1][0];
	HANDLE diskHandle = CreateFile(
		devicepath, 
		GENERIC_READ, 
		FILE_SHARE_WRITE, 
		NULL, 
		OPEN_EXISTING, 
		0, 
		NULL);

	if (diskHandle == INVALID_HANDLE_VALUE ||
		!DeviceIoControl(diskHandle, FSCTL_LOCK_VOLUME, 0, 0, 0, 0, NULL, 0) ||
		!DeviceIoControl(diskHandle, FSCTL_DISMOUNT_VOLUME, 0, 0, 0, 0, NULL, 0))
	{
		return -1;
	}
		
	DeviceIoControl(
		diskHandle, 
		IOCTL_STORAGE_EJECT_MEDIA, 
		0,
		0, 
		0,
		0, 
		NULL, 
		0);

	CloseHandle(diskHandle);

	CloseHandle(CreateFile(
		devicepath, 
		GENERIC_READ, 
		FILE_SHARE_WRITE, 
		NULL, 
		OPEN_EXISTING, 
		0, 
		NULL));

	return 0;
}