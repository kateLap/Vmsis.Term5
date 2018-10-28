#include <windows.h>
#include <conio.h>
#include <fstream>
using namespace std;

HHOOK hook;
ofstream out;

class Hooks
{

public:
	 Hooks(string _fileName)
	{
		 out.open(_fileName.c_str()); // окрываем файл дл€ записи
		 out.is_open();
	}

	 ~Hooks()
	 {
		 out.close();
	 }

	int Init(HOOKPROC keyProc, HOOKPROC mouseProc)
	{
		hook = SetWindowsHookEx(WH_KEYBOARD_LL, keyProc, NULL, 0);																			//установка процедуры хука в цепь хуков, NULL-заголовок dll, 0- ид потока, с которым процедура св€зана
		hook = SetWindowsHookEx(WH_MOUSE_LL, mouseProc, GetModuleHandle(0), 0);																	//GetModuleHandle - возвращает .exe файл вызывающего процесса
		if (hook)
		{
			while (WaitMessage())																											//приостанавливает поток, пока новое сообщение не будет помещено в очередь
			{
				MSG msg = { 0 };
																																			//(msg, hwnd-дескриптор окна, 0-все сообщени€, сообщени€ не удал€ютс€ после обработки)
				while (PeekMessage(&msg, NULL, 0, 0, PM_REMOVE))																				//провер€ет помещенные в очередь сообщени€ очереди сообщений потока и извлекает сообщение (если таковое имеетс€)
				{
					if (msg.message == WM_QUIT)
					{
						UnhookWindowsHookEx(hook);																						//удал€ет хук процедуру из цепочки хуков
						return 0;
					}
				}
			}
		}
	 }
};


LRESULT CALLBACK LowLevelMouseProc(int code, WPARAM wParam, LPARAM lParam)
{
	
	if (code < 0)
		CallNextHookEx(NULL, code, wParam, lParam);//передаЄт информацию о хуке следующей процедуре

	out << "+";
	if (wParam == WM_MOUSEWHEEL)
	{
		out << "-колЄсико-" << endl;
		
	}else 
	if (wParam == WM_RBUTTONDOWN)
	{
		out << " -> " << endl;

	}
	if (wParam == WM_LBUTTONDOWN)
	{
		out << " <- " << endl;
	}
	return 0;
}

LRESULT CALLBACK LowLevelKeyboardProc(int code, WPARAM wParam, LPARAM lParam)
{
	static int flag = 0;
	static int flagmouse = 0;
	KBDLLHOOKSTRUCT* details = (KBDLLHOOKSTRUCT*)lParam;//ввод данных с клавиатуры
	INPUT input;
	//lpar и wpar содержат информацию о нажатой клавише
	if (code == HC_ACTION && wParam == WM_KEYDOWN)
	{
		if (flag == 1)
		{
			flag = 0; 
			return 0;
		}

		if (details->vkCode >= 65 && details->vkCode <= 90)
		{
			//out << " " << (char)(details->vkCode - 65 + 'a');
			int code = details->vkCode;

			input.type = INPUT_KEYBOARD;
			input.ki.time = 0;
			if(code == 90)
			{
				input.ki.wVk = 65;
			}
			else
			{
				input.ki.wVk = code + 1;
			}			
			input.ki.dwFlags = 0;
			flag = 1;

			SendInput(1, &input, sizeof(INPUT));

			return 1;
		}
	}
	return 0;
}



int main()
{
	string fileName = "C:\\TestFile.txt";
	Hooks hooks(fileName);
	if(!hooks.Init(LowLevelKeyboardProc, LowLevelMouseProc))
	{
		return 0;
	};
}