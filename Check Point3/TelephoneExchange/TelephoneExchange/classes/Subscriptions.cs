using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class Subscriptions
    {
        private readonly ITelephoneExchange _telephoneExchange;
        private readonly IPort _port;

        private readonly ITerminal _terminal;
        public Subscriptions(TelephoneExchange ATE,Port port, Terminal terminal)
        {
            _port=port;
            _terminal = terminal;
            _telephoneExchange = ATE;
            this.Subscript();
        }
        public void Subscript()
        {
            _terminal.StartCalling -= _port.Call;
            _terminal.StartCalling += _port.Call;
            _terminal.StopCalling -= _port.StopCall;
            _terminal.StopCalling += _port.StopCall;
            _terminal.AnswerCalling -= _port.AnswerCall;
            _terminal.AnswerCalling += _port.AnswerCall;
            _port.IncomingCalling -= _terminal.HandlerRinging;
            _port.IncomingCalling += _terminal.HandlerRinging;

        }

        public void UnSubscript()
        {

            _terminal.StartCalling -= _port.Call;
            _terminal.StopCalling -= _port.StopCall;
            _terminal.AnswerCalling -= _port.AnswerCall;
            _port.IncomingCalling -= _terminal.HandlerRinging;

        }

        ~Subscriptions()
        {
            this.UnSubscript();
        }



    }
}
