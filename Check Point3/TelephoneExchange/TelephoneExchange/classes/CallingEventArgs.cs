using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class CallingEventArgs : EventArgs
    {
        public CallingEventArgs(TelephoneNumber target)
          {
              Target= target;
          }

        public TelephoneNumber Target { get; private set; }
        public CallState CallStatus { get; set; }
    }
}
