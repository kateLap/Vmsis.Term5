using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toks1
{
    class FrameState
    {
        public bool AddressRecognition { get; set; }
        public bool CopyFlag { get; set; }
        private const int Size = 2;

        public FrameState(byte addressRecognition, byte copyFlag)
        {

            AddressRecognition = addressRecognition != 0 ? true : false;
            CopyFlag = copyFlag != 0 ? true : false;
        }

        public byte[] ToBytes()
        {
            byte[] result = new byte[2];

            result[0] = (AddressRecognition == false) ? (byte)0 : (byte)1;
            result[1] = (CopyFlag == false) ? (byte)0 : (byte)1;

            return result;
        }

        public int GetSize()
        {
            return Size;
        }

    }
}
