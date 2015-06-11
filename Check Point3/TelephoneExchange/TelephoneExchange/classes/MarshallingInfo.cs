using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class MarshallingInfo
    {
        private readonly IPort _port;
        public IPort Port
        {
            get { return _port; }
        }

        private readonly ITerminal _terminal;
        public ITerminal Terminal
        {
          get { return _terminal; }  
        } 

        public MarshallingInfo(IPort port, ITerminal terminal)
        {
            _port=port;
            _terminal = terminal;
            Connect();
        }
        public void  Connect()
        {
            _terminal.StartCalling -= _port.Call;
            _terminal.StartCalling += _port.Call;
            _terminal.StopCalling -= _port.StopCall;
            _terminal.StopCalling += _port.StopCall;
            _terminal.AnswerCalling -= _port.AnswerCall;
            _terminal.AnswerCalling += _port.AnswerCall;
            _port.IncomingCalling -= _terminal.Ringing;
            _port.IncomingCalling += _terminal.Ringing;

        }

        public void Unconnect()
        {

            _terminal.StartCalling -= _port.Call;
            _terminal.StopCalling -= _port.StopCall;
            _terminal.AnswerCalling -= _port.AnswerCall;
            _port.IncomingCalling -= _terminal.Ringing;

        }





    }
}
