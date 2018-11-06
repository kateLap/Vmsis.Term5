using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IIPU_6_Tray;

namespace Usb
{
    public partial class NotifyIconForm : Form
    {
        public NotifyIconForm()
        {
            InitializeComponent();
            ListInitialization();

            this.Opacity = 0;

            this.ShowInTaskbar = false;

        }

        private List<ToolStripMenuItem> _disksList;

        void ListInitialization()
        {
            _disksList=new List<ToolStripMenuItem>();

            var drives = DriveInfo.GetDrives();

            Console.WriteLine("Список устройств для извлечения:");

            foreach (var item in drives)
            {
               
                if (item.DriveType == DriveType.Removable && item.IsReady)
                {
                    Console.WriteLine(item.Name);

                    string diskInList = "Диск " + item.Name[0].ToString();


                    _disksList.Add(new ToolStripMenuItem(diskInList));
                    _disksList[_disksList.Count - 1].Click += delegate {

                        ExtractForm extractForm = new ExtractForm(item.Name);
                        extractForm.Show();        
                        
                    };
                }
            }

            contextMenuStrip.Items.Clear();       
            contextMenuStrip.Items.AddRange(_disksList.ToArray());
            this.notifyIcon.ContextMenuStrip = contextMenuStrip;
        }


        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListInitialization();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ExitForm exitForm = new ExitForm(this);
            exitForm.Show();
        }
    }
}
