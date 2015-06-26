using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class Subscriptions //class connects the port terminal and the ATE 
    {
        public readonly ITelephoneExchange _telephoneExchange;
        internal IPort Port { get; private set; }
        internal  ITerminal Terminal { get; private set; }
        public Subscriptions(TelephoneExchange ATE,Port port, Terminal terminal)
        {
            Port = port;
            Terminal = terminal;
            _telephoneExchange = ATE;
            this.Subscript();
            this.SubscriptATE();
        }
        public void Subscript()
        {
            Terminal.StartCalling -= Port.Call;
            Terminal.StartCalling += Port.Call;
            Terminal.StopCalling -= Port.StopCall;
            Terminal.StopCalling += Port.StopCall;
            Terminal.AnswerCalling -= Port.AnswerCall;
            Terminal.AnswerCalling += Port.AnswerCall;

            Port.IncomingCalling -= Terminal.HandlerRinging;
            Port.IncomingCalling += Terminal.HandlerRinging;
            Port.ExternalStopCalling -= Terminal.ExternalStopCall;
            Port.ExternalStopCalling += Terminal.ExternalStopCall;


        }
        public void SubscriptATE()
        {
            Port.Calling -= _telephoneExchange.StartCall;
            Port.Calling += _telephoneExchange.StartCall;
            Port.StopCalling -= _telephoneExchange.StopCall;
            Port.StopCalling += _telephoneExchange.StopCall;
            Port.AnswerCalling -= _telephoneExchange.AnswerCalling;
            Port.AnswerCalling += _telephoneExchange.AnswerCalling;

        }
        public void UnSubscript()
        {
            Terminal.StartCalling -= Port.Call;
            Terminal.StopCalling -= Port.StopCall;
            Terminal.AnswerCalling -= Port.AnswerCall;
            Port.IncomingCalling -= Terminal.HandlerRinging;
            Port.ExternalStopCalling -= Terminal.ExternalStopCall;
        }
        public void UnSubscriptATE()
        {
            Port.Calling -= _telephoneExchange.StartCall;
            Port.StopCalling -= _telephoneExchange.StopCall;
            Port.AnswerCalling -= _telephoneExchange.AnswerCalling;
        }

        ~Subscriptions()
        {
            this.UnSubscript();
            this.UnSubscriptATE();
        }



    }
}
