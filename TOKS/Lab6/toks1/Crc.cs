using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toks.ThirdLab;

namespace Toks.ThirdLab
{
    public static class Crc
    {
        public static byte GetCrc(byte[] array)
        {
            const byte polynomial = 0x89;   //10001001

            if (array == null)
            {
                return (byte)0;
            }

            BitIterator iter = new BitIterator(array) {ByteIndex = 1};
            byte currentCrc = array[0];

            byte LeftShift(byte crc)
            {
                crc <<= 1;
                byte multiplier = iter.Value ? (byte)1 : (byte)0;
                crc |= multiplier;
                return crc;
            }

            for (; !iter.IsEnd; iter++)
            {
                if ((currentCrc & 0x80) != 0)
                {
                    currentCrc ^= polynomial;
                    currentCrc = LeftShift(currentCrc);
                }
                else
                {
                    currentCrc = LeftShift(currentCrc);
                }
            }

            if ((currentCrc & 0x80) != 0)
            {
                currentCrc ^= polynomial;
            }

            return currentCrc;
        }
    }
}
