using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Usb
{
    public partial class ExtractForm : Form
    {
        private string _disk;

        public ExtractForm(string disk)
        {
            InitializeComponent();
            this.Text = "Безопасное извлечение устройства";
            this._disk = disk;
            extractLabel.Text = "Извлечь безопасно диск " + disk + " ?";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string arg = _disk;
           
            System.Diagnostics.ProcessStartInfo extractProcess = new System.Diagnostics.ProcessStartInfo();
            extractProcess.FileName = @"Lab6.exe";
            extractProcess.Arguments = arg;
            System.Diagnostics.Process.Start(extractProcess);

            this.Close();
        }
    }
}