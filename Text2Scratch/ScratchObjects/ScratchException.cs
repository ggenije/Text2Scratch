using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{
    internal class ScratchException:Exception
    {
        public ScratchException():base("This shouldn't happen.")
        {
        }

        public ScratchException(string message)
            : base(message)
        {
        }

        public ScratchException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
