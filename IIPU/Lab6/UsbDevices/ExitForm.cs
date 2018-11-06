using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IIPU_6_Tray
{
    public partial class ExitForm : Form
    {
        private Form _mainForm;

        public ExitForm(Form notifyIconForm)
        {
            _mainForm = notifyIconForm;
            InitializeComponent();
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            _mainForm.Close();
            this.Close();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
