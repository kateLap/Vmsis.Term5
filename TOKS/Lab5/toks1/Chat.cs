using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using toks1;

namespace Toks.FifthLab
{
    public sealed class Chat : IDisposable
    {
        private readonly SerialPort _inputPort;
        private readonly SerialPort _outputPort;
        private readonly byte _stationAddress;
        private byte[] _bytesToSend;
        private byte _framePriority;
        private const byte _tokenPriority = 2;

        public event SerialDataReceivedEventHandler Received
        {
            add => _inputPort.DataReceived += value;
            remove => _inputPort.DataReceived -= value;
        }

        public event SerialErrorReceivedEventHandler ErrorIsThrown
        {
            add => _inputPort.ErrorReceived += value;
            remove => _inputPort.ErrorReceived -= value;
        }

        public Chat(string firstPort, string secondPort, int baud = 9600)
        {
            _inputPort = new SerialPort(firstPort,
                baud,
                Parity.None,
                8,
                StopBits.One);

            byte[] name = Encoding.UTF8.GetBytes(_inputPort.PortName);
            _stationAddress = name[name.Length - 1];

            _outputPort = new SerialPort(secondPort,
                baud,
                Parity.None,
                8,
                StopBits.One);
               
            _outputPort.Open();
            _inputPort.Open();

            _bytesToSend = null;

            Token token = new Token()
            {
                Access = new AccessControl(_tokenPriority, 0)
            };

            _framePriority = 3;

            if (((int)_stationAddress - 48) == 2)
            {
                _outputPort.Write(Encoding.UTF8.GetString(token.ToBytes()));
            }
        }

        public void WriteToClient(string message)
        {
            if (!_outputPort.IsOpen)
            {
                return;
            }

            byte[] messageInBytes = Encoding.UTF8.GetBytes(message);
            byte crc = Crc.GetCrc(messageInBytes);

            byte[] messageStuff = ByteStuffing.Stuff(messageInBytes);
            messageStuff = AddItem(messageStuff, crc);

            _bytesToSend = messageStuff;
        }

        private byte[] AddItem(byte[] array, byte item)
        {
            List<byte> list = array.ToList();
            list.Add(item);
            return list.ToArray();
        }

        public byte TrueCrc { get; private set; }
        public byte CalculatedCrc { get; private set; }
        public bool CrcEquality()
        {
            return (TrueCrc == CalculatedCrc);
        }

        public string ReceiveMessage(string destination)
        {
            string result = _inputPort.BytesToRead == 0 ? null : _inputPort.ReadExisting();         
            byte[] receivedBytes = Encoding.UTF8.GetBytes(result ?? throw new InvalidOperationException());

            if ((receivedBytes.Length <= Token.TokenSize) && (_bytesToSend != null)) //1. token && send message
            {
                if (String.IsNullOrEmpty(destination))
                {
                    _bytesToSend = null;
                    _outputPort.Write(result);
                    throw new Exception("Destination field is empty");
                }

                if (_framePriority < _tokenPriority)
                {
                    _framePriority += 2;
                    _outputPort.Write(result);
                    return null;
                }

                byte[] destInBytes = Encoding.UTF8.GetBytes(destination);

                Frame frame = new Frame()
                {
                    Destination = destInBytes[0],
                    Source = _stationAddress,
                    Access = new AccessControl(_framePriority, 1),
                    State = new FrameState(0, 0),
                    Data = _bytesToSend
                };

                _bytesToSend = null;
                _framePriority -= 2;

                _outputPort.Write(Encoding.UTF8.GetString(frame.ToBytes()));
                return null;
            }

            if ((receivedBytes.Length <= Token.TokenSize) && (_bytesToSend == null)) //2. token && !send
            {
                _outputPort.Write(result);
                return null;
            }

            if (receivedBytes.Length > Token.TokenSize) //3. frame
            {
                Frame frame = new Frame(receivedBytes);

                if (frame.Destination == _stationAddress)
                {
                    byte[] data = frame.Data;
                    TrueCrc = data[data.Length - 1];
                    Array.Resize(ref data, data.Length - 1);

                    byte[] bytesResult = ByteStuffing.ToOriginalForm(data);
                    CalculatedCrc = Crc.GetCrc(bytesResult);

                    frame.State.AddressRecognition = true;
                    frame.State.CopyFlag = true;

                    _outputPort.Write(Encoding.UTF8.GetString(frame.ToBytes()));

                    return Encoding.UTF8.GetString(bytesResult);
                }

                if (frame.Source == _stationAddress)
                {
                    if (!frame.State.AddressRecognition || !frame.State.CopyFlag)
                    {
                        throw new Exception("Data transfer error");
                    }

                    Token token = new Token()
                    {
                        Access = new AccessControl(_tokenPriority, 0)
                    };
                    
                    _outputPort.Write(Encoding.UTF8.GetString(token.ToBytes()));
                    return null;
                }

                _outputPort.Write(result);
                return null;
            }

            return null;
        }

        public void Dispose()
        {
            _inputPort.Dispose();
            _outputPort.Dispose();
        }
    }
}
