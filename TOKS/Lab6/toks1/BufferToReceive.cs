using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buffer = SerialPortChat.Buffer;

namespace SerialPortChat
{
    public class BufferToReceive : Buffer
    {
        private byte _windowBegin;

        public BufferToReceive()
        {
            _windowBegin = 1;
        }

        public override void Shift()
        {
            WindowList.Sort();

            int i;

            for (i = 0; (i < WindowList.Count) && (WindowList[i].SequenceNumber == _windowBegin)  ; i++)
            {
                _windowBegin = WindowList[i].RequiredAck;
                OutputList.Add(WindowList[i]);
                
            }

            for (int k = 0; k < i; k++)
            {
                WindowList.RemoveAt(0);
            }

        }

        public override void Add(Segment segment)
        {
            WindowList.Add(segment);
        }
    }
}
