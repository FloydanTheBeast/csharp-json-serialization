using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03
{

    [Serializable]
    public class ColorException : Exception
    {
        public ColorException() { }
        public ColorException(string message) : base(message) { }
        public ColorException(string message, Exception inner) : base(message, inner) { }
        protected ColorException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
