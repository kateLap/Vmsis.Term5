using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toks.ThirdLab;

namespace SerialPortChat
{
    public class Segment: IComparable<Segment>
    {
       public State StateInWindow { get; set; }

        public byte TrueCrc { get; }
        public byte CalculatedCrc { get; }
        public bool CrcEquality => (TrueCrc == CalculatedCrc);

        public byte RequiredAck => (byte)((int)SequenceNumber + _data.Length);
        
        public string Data
        {
            get
            {
                if (_data != null)
                {
                    return Encoding.UTF8.GetString(_data);
                }

                return null;
            }
        }

        public byte SequenceNumber { get; set; }
        public byte Acknowledgment { get; set; }

        private readonly byte _controlSum;
        private readonly byte[] _data;
        private IComparable<Segment> _comparableImplementation;

        public Segment(State state, byte[] data,  byte seqNum = 0, byte ack = 0, byte controlSum = 0, bool dataConflict = false)
        {
            SequenceNumber = seqNum;
            Acknowledgment = ack;

            StateInWindow = state;

            if (StateInWindow == State.Formed)
            {
                _controlSum = Crc.GetCrc(data);

                if (dataConflict)
                {
                    data.GenerateBytesConflict();
                }

                _data = data; //dataStuff;
            }

            else if (StateInWindow == State.Received)
            {
                CalculatedCrc = Crc.GetCrc(data);
                TrueCrc = controlSum;

                _controlSum = controlSum;
                _data = data;
            }

            else if (StateInWindow == State.Ack)
            {
                _controlSum = controlSum;
                _data = null;
            }

        }

        public override string ToString()
        {
            int dataLen;
            byte[] dataStuff = ByteStuffing.Stuff(_data);

            if (_data == null)
            {
                dataLen = 0;
            }
            else
            {           
                dataLen = dataStuff.Length;
            }

            byte[] result = new byte[3 + dataLen];

            int i = 0;

            result[i++] = SequenceNumber;
            result[i++] = Acknowledgment;
            result[i++] = _controlSum;

            if (dataStuff != null)
            {
                foreach (var item in dataStuff)
                {
                    result[i++] = item;
                }
            }

            return Encoding.UTF8.GetString(result);
        }

        public static Segment Parse(string stringSegment)
        {
            byte[] bytesSegment = Encoding.UTF8.GetBytes(stringSegment ?? throw new ArgumentNullException());

            int i = 0;

            byte sequenceNumber = bytesSegment[i++];
            byte acknowledgment = bytesSegment[i++];
            byte controlSum = bytesSegment[i++];

            List<byte> list = new List<byte>();

            for (int k = i; k < bytesSegment.Length; k++)
            {
                list.Add(bytesSegment[k]);
            }

            byte[] data;

            if (list.Any())
            {
                data = ByteStuffing.ToOriginalForm(list.ToArray());
            }
            else
            {
                data = null;
            }

            Segment requiredSegment = new Segment(State.Received, data, sequenceNumber, acknowledgment, controlSum);

            return requiredSegment;
        }

        public int CompareTo(Segment segment)
        {
            return this.SequenceNumber.CompareTo(segment.SequenceNumber);
        }
    }
}
