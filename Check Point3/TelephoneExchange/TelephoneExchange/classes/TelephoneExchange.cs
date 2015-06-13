using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class TelephoneExchange:ITelephoneExchange
    {
        
        private Dictionary<Terminal, Port> terminalPortConformity;
        public Dictionary< Terminal, Port> TerminalPortConformity
        {
            get { return terminalPortConformity; }
            private set { terminalPortConformity = value; }
        }

        private void AddTerminalPortConformity(Terminal terminal,Port port)
            {
              if(  TerminalPortConformity.ContainsValue( port ))
                  {
                      return;
                  }
              if( TerminalPortConformity.ContainsKey(terminal))
                  {
                      TerminalPortConformity[terminal] = port; 
                  }
              else
                  {
                      TerminalPortConformity.Add(terminal, port);
                  } 

            }



        private List<Subscriptions> subscriptions = new List<Subscriptions>();
        public List<Subscriptions> Subscriptions
        {
            get { return subscriptions; }
            set { subscriptions = value; }
        }

        private Queue<Port> unUsedPorts = new Queue<Port>();
        private Queue<Terminal> unUsedTerminals = new Queue<Terminal>();
        private Queue<TelephoneNumber> unUsedPhoneNumbers= new Queue<TelephoneNumber>();

        public Port GetFreePort()
        {
            return unUsedPorts.Dequeue();
        }
        public TelephoneNumber GetFreePhoneNumber()
        {
            return unUsedPhoneNumbers.Dequeue();
        }
        public Terminal GetFreeTerminal()
        {
           return unUsedTerminals.Dequeue();
        }
   
        public void CreateSubscriptions()
        {
            if (unUsedPorts.Count != 0 && unUsedTerminals.Count != 0)
            { 
                Port port = GetFreePort();
                Terminal terminal = GetFreeTerminal();
                Subscriptions.Add(new Subscriptions(this,port, terminal));
                usedTerminal.Add(terminal);
                usedPort.Add(port);
                AddTerminalPortConformity(terminal, port);
            }
        }

        public void CreateUnUsedPort()
            {
                unUsedPorts.Enqueue(new Port());
            }
        public void CreateUnUsedPhoneNumber(int number )
        {

            if (usedPhoneNumbers.Where(p => p.PhoneNumber == number) != null && unUsedPhoneNumbers.Where(p=>p.PhoneNumber==number)!=null)
            {
                return;
            }
            unUsedPhoneNumbers.Enqueue(new TelephoneNumber(number));
        }
        public void CreateUnUsedTerminal()
            {
                if (unUsedPhoneNumbers.Count!=0)
                {
                    TelephoneNumber number = GetFreePhoneNumber();
                    unUsedTerminals.Enqueue(new Terminal(number));
                    usedPhoneNumbers.Add(number);
                }
            }

        private List<TelephoneNumber> usedPhoneNumbers = new List<TelephoneNumber>();
        private List<Port> usedPort = new List<Port>();
        private List<Terminal> usedTerminal = new List<Terminal>();

        private Port FindPortTarget (Terminal terminal)
            {
                return  TerminalPortConformity[terminal];
        
            }

        

        public void StartCall(object obj,CallingEventArgs args)
          {
            


          }


    }
}
