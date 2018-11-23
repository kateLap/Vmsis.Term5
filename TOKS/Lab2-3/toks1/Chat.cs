using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace Toks.ThirdLab
{
    public sealed class Chat : IDisposable
    {
        private readonly SerialPort _serialPort;

        public bool DataConflict { get; set; }
        public bool ConflictSignal { get; set; }

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

            Random rand = new Random();
            int count = rand.Next(1, 16);

            do
            {
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                byte crc = Crc.GetCrc(messageBytes);

                if ((count > 0) && (DataConflict))
                {
                    GenerateBytesConflict(messageBytes);
                }

                byte[] messageStuff = ByteStuffing.Stuff(messageBytes);
                messageStuff = AddItem(messageStuff, crc);

                byte[] messageRepeat = messageStuff;

                if (_serialPort.CDHolding)
                {
                    _serialPort.WriteLine(Encoding.UTF8.GetString(messageRepeat));
                    
                    Thread.Sleep(CalculateSleepingTime(16 - count));
                }
                count--;
           } while (ConflictSignal);
        }

        private int CalculateSleepingTime(int count)
        {

            double k = count < 10 ? count + 1 : 8;
            int maxValue = (int)Math.Pow(2, k);
            
            return (maxValue*3);
        }

        private byte[] AddItem(byte[] array, byte item)
        {
            List<byte> list = array.ToList();
            list.Add(item);
            return list.ToArray();
        }



        public static void GenerateBytesConflict(byte[] array)
        {
            Random random = new Random();
           
            for (int i = 0; i < array.Length; i++)
            {
                int position = random.Next(0, array.Length - 3);
                array[position] = (byte) random.Next(0, byte.MaxValue);
            }
        }

        public byte TrueCrc { get; private set; }
        public byte CalculatedCrc { get; private set; }

        public void SendFrameResponse()
        {
            byte[] array = new byte[2];
            array[0] = 0x55;
            array[1] = (TrueCrc == CalculatedCrc) ? (byte)0x00 : (byte)0x55;
            _serialPort.WriteLine(Encoding.UTF8.GetString(array));
        }

        public bool CrcEquality()
        {
            return (TrueCrc == CalculatedCrc);
        }

        public string ReceiveMessage()
        {
            string result = _serialPort.BytesToRead == 0 ? null : _serialPort.ReadExisting();         
            byte[] receivedBytes = Encoding.UTF8.GetBytes(result ?? throw new InvalidOperationException());

            if (receivedBytes[0] == 0x55)
            {
                ConflictSignal = receivedBytes[1] != 0;
                return null;
            }


            TrueCrc = receivedBytes[receivedBytes.Length - 2]; //the last - \n

            Array.Resize(ref receivedBytes, receivedBytes.Length - 2);

            byte[] bytesResult = ByteStuffing.ToOriginalForm(receivedBytes);

            CalculatedCrc = Crc.GetCrc(bytesResult);

            SendFrameResponse();

            return Encoding.UTF8.GetString(bytesResult);
        }

        public void Dispose()
        {
            _serialPort.Dispose();
        }
    }
}
