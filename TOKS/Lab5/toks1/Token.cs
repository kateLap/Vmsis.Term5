using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toks1
{
    class Token
    {
        public AccessControl Access { get; set; }

        protected const byte _begin = 0x11;
        protected const byte _end = 0x7E;

        public static int TokenSize = 8;

        public virtual byte[] ToBytes()
        {
            byte[] result = new byte[2 + Access.GetSize()];

            int index = 0;
            result[index++] = _begin;

            byte[] accessInBytes = Access.ToBytes();

            foreach (var item in accessInBytes)
            {
                result[index++] = item;
            }

            result[index] = _end;

            return result;
        }

        public Token(byte[] array)
        {
            int index = 1;
            Access = new AccessControl(array[index++], array[index++]);
        }

        public Token()
        {

        }
    }
}
