#pragma once
#include "DiskProperties.h"
#include <ntddscsi.h>
#include <iostream>
using namespace std;

class StorageInfo {
	DiskProperties drive;
	HANDLE disk;

public:
	StorageInfo() {

		disk = CreateFile(
			"\\\\.\\PhysicalDrive0",		// ���
			GENERIC_READ | GENERIC_WRITE,	// ������
			FILE_SHARE_READ,				// ��������� ����������� �������� �������� �������, ������� ������� ������� ���  ������
			NULL,							// �����. ������
			OPEN_EXISTING,
			NULL,							//�������� �����
			NULL							//���������� ������� �����
		);
		if (disk == INVALID_HANDLE_VALUE) {
			cout << "Can't get access to HDD" << endl;
			exit(-1);
		}
	}

	void hddInfo() {
		const char* buses[14] = { "Unknown", "SCSI", "ATAPI", "ATA",
		"1394", "SSA", "Fibre", "USB", "RAID",
		"ISCSI", "SAS", "SATA", "SD", "MMC" };

		STORAGE_PROPERTY_QUERY storagePropertyQuery;			 //�������� ���������� ��������
		storagePropertyQuery.QueryType = PropertyStandardQuery;  //��� �������: �������� �������� �������� ���������� ����������
		storagePropertyQuery.PropertyId = StorageDeviceProperty; //���������, ��� ���������� ������ ����������� ���������� ����������, STORAGE_DEVICE_DESCRIPTOR.

		STORAGE_DEVICE_DESCRIPTOR* deviceDescriptor = (STORAGE_DEVICE_DESCRIPTOR*)calloc(1024, 1);//��������� ��� ������ ���������� ��������

		if (!DeviceIoControl(
			disk,							// hDevice
			IOCTL_STORAGE_QUERY_PROPERTY,	// ����������� ��� ��� �������� ������� ���������� ��������
			&storagePropertyQuery,			// lplnBuffer 
			sizeof(storagePropertyQuery),	// nlnBufferSize
			deviceDescriptor,				// lpOutBuffer
			1024,							// nOutBufferSize
			NULL,							// lpBytesReturned
			NULL							// lpOverlapper
		)) {
			cout << GetLastError() << endl;
			CloseHandle(disk);
			exit(-1);
		}

		drive.Id = (char*)(deviceDescriptor) + deviceDescriptor->ProductIdOffset;
		drive.Revision = (char*)(deviceDescriptor) + deviceDescriptor->ProductRevisionOffset;
		drive.Bus = (char*)buses[deviceDescriptor->BusType];
		drive.SerialNumber = (char*)(deviceDescriptor) + deviceDescriptor->SerialNumberOffset;
		memoryCounting();
		supportModes();
	}

	void memoryCounting() {
		const int BytesInMegabyte = 1048576;
		_ULARGE_INTEGER spaceInMegabytes, spaceInBytes, freeSpaceInMegabytes, freeSpaceInBytes;
		spaceInMegabytes.QuadPart = freeSpaceInMegabytes.QuadPart = 0;

		unsigned long int numberOfLogDrives = GetLogicalDrives();				//������� 0 - ���� �, 1 - B, 2 - C

		for (char ch = 'A'; ch < 'Z'; ch++) {
			if ((numberOfLogDrives >> ch - 65) & 1) {
				string path;
				path = ch;
				path.append(":\\");
				if (GetDriveType(path.c_str()) == DRIVE_FIXED) {				//������ ����� ������������� ��������(��)
					GetDiskFreeSpaceEx(path.c_str(), 0, &spaceInBytes, &freeSpaceInBytes);
					spaceInMegabytes.QuadPart += spaceInBytes.QuadPart / BytesInMegabyte;
					freeSpaceInMegabytes.QuadPart += freeSpaceInBytes.QuadPart / BytesInMegabyte;
				}
			}
		}
		drive.totalSpace = spaceInMegabytes.QuadPart;
		drive.freeSpace = freeSpaceInMegabytes.QuadPart;
	}

	/*string GetManufacter() {
		HDEVINFO DeviceInfoSet = SetupDiGetClassDevs(&GUID_DEVCLASS_DISKDRIVE, "SCSI", NULL, DIGCF_PRESENT | DIGCF_ALLCLASSES);
		char deviceName[256];
		SP_DEVINFO_DATA DeviceInfoData;
		DeviceInfoData.cbSize = sizeof(SP_DEVINFO_DATA);
		SetupDiEnumDeviceInfo(DeviceInfoSet, 1, &DeviceInfoData);
		SetupDiGetDeviceRegistryProperty(DeviceInfoSet, &DeviceInfoData, SPDRP_MFG, NULL, (PBYTE)deviceName, sizeof(deviceName), 0);
		SetupDiDestroyDeviceInfoList(DeviceInfoSet);
		return deviceName;
	}*/

	void supportModes() {

		UCHAR identifyDataBuffer[560] = { 0 };
		ATA_PASS_THROUGH_EX &apte = *(ATA_PASS_THROUGH_EX *)identifyDataBuffer;

		apte.Length = sizeof(apte);
		apte.TimeOutValue = 10;								//����� �������
		apte.DataTransferLength = 512;						//������ ������ ������
		apte.DataBufferOffset = sizeof(ATA_PASS_THROUGH_EX);
		apte.AtaFlags = ATA_FLAGS_DATA_IN;					//������ ������ �� ����������

															//��������� ����������� ��������� ����������� IDE
		IDEREGS *regs = (IDEREGS *)apte.CurrentTaskFile;    //���������� ���������� �������� ������ �����
		regs->bCommandReg = 0xEC;						    //������������� �����

		DeviceIoControl(
			disk,
			IOCTL_ATA_PASS_THROUGH,							//������ ��������� ���������� ����� ������� ATA �� ���.����
			&apte,
			sizeof(identifyDataBuffer),
			&apte,
			sizeof(identifyDataBuffer),
			NULL,
			NULL
		);

		WORD *data = (WORD *)(identifyDataBuffer + sizeof(ATA_PASS_THROUGH_EX));
		//drive.setSupportMode(data[80], drive.ata);
		drive.setSupportMode(data[63], drive.dma);
		drive.setSupportMode(data[63], drive.pio);
	}

	void Show() {
		setlocale(LC_ALL, "rus");
		cout << "���������� � ������� �����" << endl;
		cout << "***********************************" << endl;
		cout << "������ �����: " << drive.Id << endl << endl;
		
		cout << "�������� �����: " << drive.SerialNumber << endl << endl;
		cout << "������: " << drive.Revision << endl << endl;
		cout << "����: " << drive.Bus << endl << endl;
		cout << "������ �������������� �������:" << endl;
		cout << "PIO:   ";
		for (int i = 0; i < 2; i++) {
			if (drive.pio[i] == 1)
				cout << "PIO" << i + 3 << ", ";
		}
		cout << endl;
		/*cout << endl << endl;
		cout << "ATA: ";
		for (int i = 8; i >= 4; i--) {
			if (drive.ata[i] == 1)
				cout << "ATA" << i << ", ";
		}
		cout << endl << endl;*/
		cout << "DMA: ";
		for (int i = 0; i < 8; i++) {
			if (drive.dma[i] == 1)
				cout << "DMA" << i << ", ";
		}
		cout << endl;
		cout << "*********************************" << endl;
		cout << "�������� � ������: " << endl;
		cout << "��������: " << drive.freeSpace << " Mb" << endl;
		cout << "������: ";
		cout << std::setprecision(3) << 100.0 - ((double)drive.freeSpace / (double)drive.totalSpace * 100);
		cout << "%" << endl;
		cout << "����� ������: " << drive.totalSpace << " Mb" << endl << endl;
		
		cout << "*********************************" << endl;
	}
};