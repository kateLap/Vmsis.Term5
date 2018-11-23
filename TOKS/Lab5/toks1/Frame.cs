using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toks1
{
    class Frame : Token
    {
        public byte Destination { get; set; }

        public byte Source { get; set; }
        public byte[] Data {  get; set; }
        public FrameState State { get; set; }

        public override byte[] ToBytes()
        {
            byte[] result = new byte[3 + State.GetSize() + Data.Length + 2 + Access.GetSize()];

            int index = 0;
            result[index++] = _begin;

            byte[] accessInBytes = Access.ToBytes();

            foreach (var item in accessInBytes)
            {
                result[index++] = item;
            }

            result[index++] = Destination;
            result[index++] = Source;

            foreach (var item in Data)
            {
                result[index++] = item;
            }

            result[index++] = _end;

            byte[] stateInBytes = State.ToBytes();

            foreach (var item in stateInBytes)
            {
                result[index++] = item;
            }

            return result;
        }

        public Frame(byte[] array)
        {
            int index = 1;
            this.Access = new AccessControl(array[index++], array[index++]);
            this.Destination = array[index++];
            this.Source = array[index++];

            List<byte> dataList = new List<byte>();
            dataList.Add(array[index++]);
            //index++;
            for (; array[index] != _end; index++)
            {
                dataList.Add(array[index]);
            }

            this.Data = dataList.ToArray();
            this.State = new FrameState(array[index++], array[index++]);
        }

        public Frame(){ }
    }
}
