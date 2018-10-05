using System;
using System.Windows.Forms;

namespace Battery
{
    public partial class Battery : Form
    {
        private readonly BatteryManager _batteryManager = new BatteryManager();

        public Battery()
        {
            InitializeComponent();
        }

        private void BatteryLoad(object sender, EventArgs e)
        {
            _batteryManager.Init();
            UpdateBattery(null, null);

            UpdateTimer.Tick += UpdateBattery;
            UpdateTimer.Interval = 2000;
            UpdateTimer.Start();
        }

        private void UpdateBattery(object sender, EventArgs e)
        {
            _batteryManager.UpdateData();
            State.Text = _batteryManager.charging;
            BatteryPercents.Text = _batteryManager.percentBattery;
            timeLeft.Text = _batteryManager.workTime;
            BatteryModeTextBox.Text = _batteryManager.BatteryMode;
            AcModeTextBox.Text = _batteryManager.AcMode;         
        }
    }
}