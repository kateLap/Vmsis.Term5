using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerialPortChat;
using Buffer = SerialPortChat.Buffer;

namespace SerialPortChat
{
    public class BufferToSend: Buffer
    {
        private byte _currentSeqNumber;

        public BufferToSend()
        {
            _currentSeqNumber = 1;
        }

        public int UnconfirmedSegments()
        {
            if (WindowList.Any() && (WindowList.First().StateInWindow == State.Confirmed))
            {
                return 0;
            }

            var unconfirmedSegs = WindowList.TakeWhile(s => s.StateInWindow == State.Unconfirmed);
            return unconfirmedSegs.Count();
        }

        public override void Add(Segment segment)
        {
            segment.SequenceNumber = _currentSeqNumber;
            _currentSeqNumber += (byte)segment.Data.Length;

            WindowList.Add(segment);
        }

        public override void Shift()
        {
            var segments = WindowList.TakeWhile(s => s.StateInWindow == State.Confirmed);
            OutputList.AddRange(segments);

            WindowList.RemoveRange(0, segments.Count());
        }
        
    }
}
