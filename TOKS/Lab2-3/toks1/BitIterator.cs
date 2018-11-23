using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toks.ThirdLab
{
    public class BitIterator
    {
        public bool IsEnd { get; private set; }

        public BitIterator(byte[] array)
        {
            this._arrayToIterate = array;
            _byteIndex = 0;
            _bitPosition = 0;
            IsEnd = false;
        }

        public bool Value
        {
            get
            {
                byte multiplier = 1;
                multiplier <<= (BitsInByte - 1) - _bitPosition;
                return (_arrayToIterate[_byteIndex] & multiplier) != 0 ? true : false;
            }
        }
        
        public int ByteIndex
        {
            get { return _byteIndex; }
            set
            {
                if (value >= _arrayToIterate.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _byteIndex = value;
            }
        }     

        public static BitIterator operator ++(BitIterator iter)
        {
            if (!iter.IsEnd)
            {
                if (iter._bitPosition < BitsInByte - 1)
                {
                    iter._bitPosition++;
                }
                else if (iter._byteIndex < iter._arrayToIterate.Length - 1)
                {
                    iter._bitPosition = 0;
                    iter._byteIndex++;
                }
                else
                {
                    iter.IsEnd = true;
                }
            }
            return iter;
        }

        private const int BitsInByte = 8;
        private int _bitPosition;
        private int _byteIndex;
        private readonly byte[] _arrayToIterate;
    }
}
