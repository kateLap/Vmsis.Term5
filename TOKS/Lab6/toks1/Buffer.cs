using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortChat
{
    public class Buffer
    {
        public List<Segment> OutputList { get; set; }
        public List<Segment> WindowList { get; set; }

        public Buffer()
        {
            OutputList = new List<Segment>();
            WindowList = new List<Segment>();
        }

        public virtual void Shift() { }

        public virtual void Add(Segment segment) { }

    }
}
