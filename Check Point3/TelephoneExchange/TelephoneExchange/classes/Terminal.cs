using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class Terminal:ITerminal
    {
        public TelephoneNumber MyPhoneNumber { get;  private set; }
        public Terminal(TelephoneNumber number)
          {
              MyPhoneNumber = number;
          }
        public TerminalState TerminalStatus { get; private set; }
        public event EventHandler<CallingEventArgs> StartCalling;
        protected virtual void OnStartCalling(int targetNumber)
            {
                CallingEventArgs e = new CallingEventArgs(targetNumber,MyPhoneNumber.PhoneNumber);
                if (StartCalling != null)
                {
                    StartCalling(this, e);
                }
                
            }
        public void Call(int targetNumber)
        {
            if (TerminalStatus==TerminalState.on)
            {
                OnStartCalling(targetNumber);
                TerminalStatus = TerminalState.call;
            }
          
        }
        public event EventHandler StopCalling;
        protected virtual void OnStopCalling()
        {

            if (StopCalling != null)
            {
                StopCalling(this, EventArgs.Empty);
            }
           
        }
        public void StopCall()
        {
            if (TerminalStatus == TerminalState.busy || TerminalStatus == TerminalState.call )
            {
                OnStopCalling();
                TerminalStatus = TerminalState.on;
            }

        }
        public event EventHandler AnswerCalling;
        protected virtual void OnAnswerCall()
        {

            if (AnswerCalling != null)
            {
                AnswerCalling(this, EventArgs.Empty);
            }

        }
        public void AnswerCall()
        {
            if (TerminalStatus == TerminalState.busy)
            {
                OnAnswerCall();
                TerminalStatus = TerminalState.call;
            }

        }
        public void HandlerRinging(Object obj, EventArgs args)
            {
                if (TerminalStatus == TerminalState.on)
                {
                    TerminalStatus = TerminalState.busy;
                }
            }
        public void ExternalStopCall(Object obj, EventArgs args)
            {
                if(TerminalStatus==TerminalState.call || TerminalStatus==TerminalState.busy)
                {
                    TerminalStatus = TerminalState.on;
                }
            }
        public void Plug()
        {
            if (TerminalStatus==TerminalState.off)
            {
                TerminalStatus = TerminalState.on;
            }
        }
        public void UnPlug()
        {
            if(TerminalStatus==TerminalState.on)
            {
                TerminalStatus = TerminalState.off;
            }

        }





    }
}
