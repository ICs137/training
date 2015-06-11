using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class TelephoneExchange
    {
        private Dictionary<Port, Terminal> portTerminalConformity;

        public Dictionary<Port, Terminal> PortTerminalConformity
        {
            get { return portTerminalConformity; }
            set { portTerminalConformity = value; }
        }




    }
}
