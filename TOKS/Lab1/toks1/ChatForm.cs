using System;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using toks1;

namespace toks
{
    public partial class ChatForm : Form
    {
        private Chat _chat;

        public ChatForm()
        {
            InitializeComponent();
            SendTextBox.ScrollBars = ScrollBars.Vertical;
            ChatTextBox.ScrollBars = ScrollBars.Vertical;
            ChatTextBox.ReadOnly = true;

            this.SendTextBox.KeyUp += new KeyEventHandler((x, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ButtonSend_Click(x, e);
                }
            });
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            _chat.WriteToClient(SendTextBox.Text);
            var user = "Me : ";
            ChatTextBox.Text += user + SendTextBox.Text;
            SendTextBox.Clear();
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            PortsComboBox.Items.AddRange(ports);
            CloseButton.Enabled = false;

            int[] baud = new[] {300, 600, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200};
            foreach (var i in baud)
            {
                BaudComboBox.Items.Add(i);
            }

            BaudComboBox.Text = "9600";
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {         
            try
            {
                _chat = new Chat(PortsComboBox.Text, Int32.Parse(BaudComboBox.Text));

                _chat.Received += DataReceive;
                _chat.ErrorIsThrown += ErrorReceive;

                OpenButton.Enabled = false;
                CloseButton.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            _chat.Dispose();
            OpenButton.Enabled = true;
            CloseButton.Enabled = false;
        }

        private void DataReceive(object sender, SerialDataReceivedEventArgs e)
        {
            string message = _chat.ReceiveMessage();
            ChatTextBox.Text += message + Environment.NewLine;
        }

        private void ErrorReceive(object sender, SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show("Serial port error!");
        }
    }
}
