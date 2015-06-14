using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    interface ITerminal
    {
         TelephoneNumber MyPhoneNumber { get; }
         event EventHandler<CallingEventArgs> StartCalling;
         void Call(int targetNumber);
         event EventHandler StopCalling;
         void StopCall();
         event EventHandler AnswerCalling;
         void AnswerCall();
         void HandlerRinging(Object obj, EventArgs args);
         void ExternalStopCall(Object obj, EventArgs args);
    }
}
