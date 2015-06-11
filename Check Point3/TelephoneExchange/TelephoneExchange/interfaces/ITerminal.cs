using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    interface ITerminal
    {
        public TelephoneNumber MyPhoneNumber { get; }
        public event EventHandler<CallingEventArgs> StartCalling;
        protected virtual void OnStartCalling(TelephoneNumber targetNumber);
        public void Call(TelephoneNumber targetNumber);
        public event EventHandler StopCalling;
        protected virtual void OnStopCalling();
        public void StopCall();
        public event EventHandler AnswerCalling;
        protected virtual void OnAnswerCall();
        public void AnswerCall();
        public void Ringing(Object obj,CallingEventArgs args);

    }
}
