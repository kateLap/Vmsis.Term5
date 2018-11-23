using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using SerialPortChat;


namespace Toks.ThirdLab
{
    public sealed class Chat : IDisposable
    {
        private readonly SerialPort _serialPort;

        private Segment _mixSegment;

        public BufferToSend BufferToSend { get; set; }
        public BufferToReceive BufferToReceive { get; set; }

        private int _errorCount;

        public bool DataConflict { private get; set; }

        public bool Mixing { private get; set; }
        public bool Deleting { private get; set; }

        public byte TrueCrc { get; private set; }

        public byte CalculatedCrc { get; private set; }

        public bool CrcEquality { get; set; }

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

            BufferToSend = new BufferToSend();
            BufferToReceive = new BufferToReceive();

            _errorCount = 0;
            _mixSegment = null;
        }

        public void DataTransfer(string message)
        {
            if (!_serialPort.IsOpen)
            {
                return;
            }


            Segment segment = new Segment(State.Formed, Encoding.UTF8.GetBytes(message), dataConflict: DataConflict);

            BufferToSend.Add(segment);

            segment.StateInWindow = State.Unconfirmed;

            _serialPort.Write(segment.ToString());

        }

        public string[] ReceiveMessage()
        {
            string stringSegment = _serialPort.BytesToRead == 0 ? null : _serialPort.ReadExisting(); 
            
            Segment segment = Segment.Parse(stringSegment);

            byte ack = segment.Acknowledgment;

            if (ack > 0)        //sender (ACK)
            {
                Segment segToConfirm = BufferToSend.WindowList.Find(s => s.RequiredAck == ack);
                segToConfirm.StateInWindow = State.Confirmed;

                BufferToSend.Shift();

                int errorCount = BufferToSend.UnconfirmedSegments();

                if (errorCount != 0)
                {
                    _errorCount++;

                    if (_errorCount > 3)
                    {
                        for (int i = 0; i < errorCount; i++)
                        {
                            _serialPort.Write(BufferToSend.WindowList[i].ToString());
                        }

                        _errorCount = 0;
                    }
                }

                return null;
            }
                                                         //receiver (SEG)
            if (Deleting)
            {
                return null;
            }

            if (Mixing)
            {
                _mixSegment = segment;

                CrcEquality = segment.CrcEquality;

                if (!CrcEquality) throw new Exception("Crc error!!!");
                TrueCrc = segment.TrueCrc;
                CalculatedCrc = segment.CalculatedCrc;
                Segment segA = new Segment(State.Ack, null, ack: segment.RequiredAck);
                _serialPort.Write(segA.ToString());
                return null;
            }

            BufferToReceive.Add(segment);

            if (_mixSegment != null)
            {
                BufferToReceive.Add(_mixSegment);

                _mixSegment = null;
            }

            BufferToReceive.Shift();

                CrcEquality = segment.CrcEquality;

                if(!CrcEquality) throw new Exception("Crc error!!!");

                TrueCrc = segment.TrueCrc;
                CalculatedCrc = segment.CalculatedCrc;

                Segment segAck = new Segment(State.Ack, null, ack: segment.RequiredAck);

                _serialPort.Write(segAck.ToString());

                List<string> strings = new List<string>();

                foreach (var item in BufferToReceive.OutputList)
                {
                    strings.Add(item.Data);
                }

                BufferToReceive.OutputList.Clear();

                return strings.ToArray();

        }

        public void Dispose()
        {
            _serialPort.Dispose();
        }
    }
}
