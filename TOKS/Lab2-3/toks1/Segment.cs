using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toks1
{
    public class Segment
    {
        private int _sequenceNumber;
        private int _acknowledgment;

        private byte _windowSize;
        private byte _controlSum;

        private byte[] data;
    }
}
