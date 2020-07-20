using System;
using System.Collections.Generic;
using System.Text;

namespace HeapTree
{
    class HeapEmptyException : Exception
    {
        public HeapEmptyException(string msg) : base(msg)
        {

        }
    }
}
