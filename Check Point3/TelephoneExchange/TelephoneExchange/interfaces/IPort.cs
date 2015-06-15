using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
     interface IPort
    {
        PortState PortStatus { get; set; }  
        event EventHandler<CallingEventArgs> Calling;
        void Call(Object obj, CallingEventArgs args);
        event EventHandler StopCalling;
        void StopCall(Object obj, EventArgs args);
        void StopCall();
        event EventHandler ExternalStopCalling;
        event EventHandler AnswerCalling;
        void AnswerCall(Object obj, EventArgs args);
        event EventHandler IncomingCalling;
        void IncomingCall();
          
    }
}
