using System;
using System.Collections.Specialized;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace toks1
{
    public sealed class Chat : IDisposable
    {
        private readonly SerialPort _serialPort;

        public event SerialDataReceivedEventHandler Received
        {
            add => _serialPort.DataReceived += value;
            remove => _serialPort.DataReceived -= value;
        }

        public event SerialErrorReceivedEventHandler ErrorIsThrown
        {
            add => _serialPort.ErrorReceived += value;
            remove => _serialPort.ErrorReceived -= value;
        }

        public Chat(string portName, int baud = 9600)
        {
            _serialPort = new SerialPort(portName,
                baud,
                Parity.None,
                8,
                StopBits.One);

            _serialPort.Open();
        }

        public void WriteToClient(string message)
        {
            if (!_serialPort.IsOpen)
            {
                return;
            }

            _serialPort.WriteLine(message);

        }

        public string ReceiveMessage()
        {
            string result = _serialPort.BytesToRead == 0 ? null : _serialPort.ReadExisting();

            return result;
        }

        public void Dispose()
        {
            _serialPort.Dispose();
        }
    }
}
