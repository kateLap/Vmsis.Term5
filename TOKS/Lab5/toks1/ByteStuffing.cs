using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toks.FifthLab
{
    public static class ByteStuffing
    {
        private const byte StartFlag = 0x7E;
        private const byte AdditionalByte = 0x5E;

        public static byte[] Stuff(byte[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} refers null");
            }

            int count = 0;

            foreach (var item in source)
            {
                count++;
                if ((item == StartFlag) || (item == StartFlag - 1))
                    count++;
            }

            byte[] result = new byte[++count];

            result[0] = StartFlag;

            for (int i = 0, j = 1; i < source.Length; i++, j++)
            {
                if ((source[i] == StartFlag) || (source[i] == StartFlag - 1))
                {
                    result[j++] = StartFlag - 1;
                    result[j] = (byte)(source[i] & 0x5F);
                }
                else
                {
                    result[j] = source[i];
                }
            }

            return result;
        }

        public static byte[] ToOriginalForm(byte[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} refers null");
            }

            int count = source.Length - 1;
            for (int i = 1; i < source.Length - 1; i++)
            {
                if ((source[i] == StartFlag - 1) && ((source[i+1] == AdditionalByte) || (source[i+1] == AdditionalByte - 1)))
                    count--;
            }

            byte[] result = new byte[count];
            
            for (int i = 1, j = 0; i < source.Length; i++ , j++)
            {
                if (source[i] == StartFlag - 1)
                {
                    result[j] = StartFlag;
                    if (source[i + 1] == AdditionalByte - 1)
                    {
                        result[j] -= 1;
                    }
                    i++;
                }
                else
                {
                    result[j] = source[i];
                }
            }

            return result;
        }
    }
}
