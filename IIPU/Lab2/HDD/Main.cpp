#include <iomanip>
#include <Windows.h>
#include "StorageInfo.h"

using namespace std;

int main() {
	StorageInfo info;

	info.hddInfo();
	info.Show();

	system("pause");
	return 0;
}