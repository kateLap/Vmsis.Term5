using System;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Toks.ThirdLab;

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
            chatInfoTextBox.ReadOnly = true;

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
            chatInfoTextBox.Clear();
            if (_chat == null)
            {
                return;
            }

            _chat.DataConflict = dataConflictCheckBox.CheckState == CheckState.Checked ? true : false;

            _chat.WriteToClient(SendTextBox.Text);         
            
            ChatTextBox.Text += "Me: " + SendTextBox.Text;
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

            chatInfoTextBox.Clear();

            if (message == null)
            {
                if (_chat.ConflictSignal)
                {
                    chatInfoTextBox.Text += "Last data conflict. Transfer will repeat...";
                }
                else
                {
                    chatInfoTextBox.Text += "Successful transfer.";
                }
                return;
            }
            
            ChatTextBox.Text += message;

            if (!_chat.CrcEquality())
            {
                chatInfoTextBox.Text += "Data conflict!!!" + Environment.NewLine;
            }

            chatInfoTextBox.Text += "CRC in original:" + Environment.NewLine;
            chatInfoTextBox.Text += _chat.TrueCrc + Environment.NewLine;
            chatInfoTextBox.Text += "CRC of the receiver:" + Environment.NewLine;
            chatInfoTextBox.Text += _chat.CalculatedCrc + Environment.NewLine;

        }

        private void ErrorReceive(object sender, SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show("Serial port error!");
        }

    }
}
