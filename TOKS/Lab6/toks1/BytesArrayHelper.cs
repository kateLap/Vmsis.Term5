using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortChat
{
    public static class BytesArrayHelper
    {
        public static void GenerateBytesConflict(this byte[] array)
        {
            if (array == null)
            {
                return;
            }

            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                int position = random.Next(0, array.Length - 3);
                array[position] = (byte)random.Next(0, byte.MaxValue);
            }
        }
    }
}
