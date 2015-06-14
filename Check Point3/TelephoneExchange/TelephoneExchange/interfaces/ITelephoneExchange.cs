using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TelephoneExchange
{
    public interface ITelephoneExchange
    {

        void StartCall(object obj, CallingEventArgs args);
        void StopCall(object obj, EventArgs argss);
        void AnswerCalling(object obj, EventArgs args);
    }
}
