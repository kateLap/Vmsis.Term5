using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace toks1
{
    class AccessControl
    {
        private byte _priority;
        private MarkerState _state;
        private const int Size = 2;

        public AccessControl(byte priority, byte state)
        {
            _priority = priority;
            _state = state != 0 ? MarkerState.Frame : MarkerState.Marker;
        }

        public byte[] ToBytes()
        {
            byte[] result = new byte[2];
            result[0] = _priority;
            result[1] = (_state == MarkerState.Marker) ? (byte)0 : (byte)1;

            return result;
        }

        public int GetSize()
        {
            return Size;
        }
    }
}
