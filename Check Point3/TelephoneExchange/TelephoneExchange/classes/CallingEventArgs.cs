using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class CallingEventArgs
    {
        public CallingEventArgs(int target, int initiator)
        {
            Target = target;
            Initiator = initiator;
        }

    public  CallState CallStatus { get; set; }
    public  int Initiator { get; private set; }
    public  int Target { get;private set; }
    
    }
}
