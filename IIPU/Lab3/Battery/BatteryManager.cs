using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Battery
{
    public sealed class BatteryManager
    {
        public string charging { get; set; }
        public string percentBattery { get; set; }
        public string workTime { get; set; }

        public string previousCharging { get; set; }

        public bool startApp { get; set; }

        public string BatteryMode { get; private set; }
        public string AcMode { get; private set; }

        public void Init()
        {
            startApp = true;

            GetEnergySavingMode();
            UpdateData();
        }

        private void GetEnergySavingMode()
        {
            var procCmd = new Process();                                //запуск системного процесса
            procCmd.StartInfo.UseShellExecute = false;                  //CreateProcess function
            procCmd.StartInfo.RedirectStandardOutput = true;            //текстовый вывод приложения записывается в поток StandardOutput
            procCmd.StartInfo.CreateNoWindow = true;
            procCmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;  //скрытый стиль окна
            procCmd.StartInfo.FileName = "cmd.exe";                     //определяет приложение для запуска
            procCmd.StartInfo.Arguments = "/c powercfg /q";             //отображение схемы управления питанием
            procCmd.Start();

            var powerConfig = procCmd.StandardOutput.ReadToEnd();
            var lastStringBattery = new Regex("12bbebe6-58d6-4636-95bb-3217ef867c1a.*\\n.*\\n.*\\n.*\\n.*\\n.*\\n.*\\n.*\\n.*\\n.*\\n.*");
            var lastStringAc = new Regex("12bbebe6-58d6-4636-95bb-3217ef867c1a.*\\n.*\\n.*\\n.*\\n.*\\n.*\\n.*\\n.*\\n.*\\n.*");

            var regBattery = lastStringBattery.Match(powerConfig).Value;
            var regAc = lastStringAc.Match(powerConfig).Value;

            var batteryState = regBattery.Substring(regBattery.Length - 11).TrimEnd();
            var AcState = regAc.Substring(regAc.Length - 11).TrimEnd();

            BatteryMode = GetEnergySavingMode((Convert.ToInt32(batteryState, 16)));
            AcMode = GetEnergySavingMode((Convert.ToInt32(AcState, 16)));
        }

        private string GetEnergySavingMode(int mode)
        {
            string result = null;
            switch (mode)
            {
                case 0:
                {
                    result = "Максимальная производительность";
                    break;
                }
                case 1:
                {
                    result = "Минимальное энергосбережение";
                    break;
                }
                case 2:
                {
                    result = "Среднее энергосбережение";
                    break;
                }
                case 3:
                {
                    result = "Максимальное энергосбережение";
                    break;
                }
            }
            return result;
        }

        public void UpdateData()//получение текущего состояния батареи
        {
            charging = SystemInformation.PowerStatus.PowerLineStatus.ToString();//online, offline, unknown

            if (startApp)
            {
                previousCharging = charging;
                startApp = false;
            }

            percentBattery = SystemInformation.PowerStatus.BatteryLifePercent * 100 + "%";

            if (charging == "Offline")
            {
                var calcLife = SystemInformation.PowerStatus.BatteryLifeRemaining;

                if (calcLife != -1)
                {
                    var span = new TimeSpan(0, 0, calcLife);
                    workTime = span.ToString("g");//формат 0:00:00
                }
                else workTime = "Измерение времени...";
            }
            else
            {
                workTime = "Зарядное устройство";
            }
        }
    }
}