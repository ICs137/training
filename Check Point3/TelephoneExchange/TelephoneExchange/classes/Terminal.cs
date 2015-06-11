using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class Terminal
    {
        public TelephoneNumber MyPhoneNumber { get;  private set; }
        public Terminal(TelephoneNumber number)
          {
              MyPhoneNumber = number;
          }
        public TerminalState TerminalStatus { get; private set; }
        public event EventHandler<CallingEventArgs> StartCalling;

        protected virtual void OnStartCalling(TelephoneNumber targetNumber)
            {
                CallingEventArgs e = new CallingEventArgs(targetNumber);
                if (StartCalling != null)
                {
                    StartCalling(this, e);
                }
                Console.WriteLine(e.CallStatus);
            }

        public void Call(TelephoneNumber targetNumber)
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
                StopCalling(this,EventArgs.Empty);
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

        public void Ringing(object obj,CallingEventArgs args)
            {
                if (TerminalStatus == TerminalState.on)
                {
                    TerminalStatus = TerminalState.busy;
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
