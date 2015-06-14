using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class TelephoneExchange:ITelephoneExchange
    {

        private List<CallInfo> ActiveCalls = new List<CallInfo>();
        private List<Subscriptions> subscriptions = new List<Subscriptions>();
        public List<Subscriptions> Subscriptions
        {
            get { return subscriptions; }
            set { subscriptions = value; }
        }

        private Queue<Port> unUsedPorts = new Queue<Port>();
        private Queue<Terminal> unUsedTerminals = new Queue<Terminal>();
      

        public Port GetFreePort()
        {
            return unUsedPorts.Dequeue();
        }
        public Terminal GetFreeTerminal()
        {
           return unUsedTerminals.Dequeue();
        }

        private void CreateSubscriptions(Port port, Terminal terminal)
        {
         
          Subscriptions.Add(new Subscriptions(this,port, terminal));
        
        }
        public void CreateUnUsedPort()
            {
                unUsedPorts.Enqueue(new Port());
            }
        public void CreateUnUsedTerminal( int newNumber)
            {
                if (CheckPhoneNumber(newNumber))
                {
                    Console.WriteLine(" This number is busy");
                    return;
                }
                   TelephoneNumber number = new  TelephoneNumber(newNumber);
                   unUsedTerminals.Enqueue(new Terminal(number));
            }

        private bool CheckPhoneNumber(int number)
        {
            if (Subscriptions.FirstOrDefault(p => p.Terminal.MyPhoneNumber.PhoneNumber == number) != null || unUsedTerminals.FirstOrDefault(p => p.MyPhoneNumber.PhoneNumber == number) != null)
            {
                return true;
            }
            return false;
        }
        private IPort FindPort (int number)
            {
                Subscriptions temp=Subscriptions.SingleOrDefault(p=>p.Terminal.MyPhoneNumber.PhoneNumber==number);
                return temp.Port;
            }
        public void StartCall(object obj,CallingEventArgs args)
          { 
 
              IPort portTarget = FindPort(args.Target);
              Port portInitiator =  (obj as Port);

              ActiveCalls.Add(new CallInfo(args) { PortInitiator = portInitiator, PortTarget = portTarget });

              if (portTarget != null)
              {
                  if (portTarget.PortStatus == PortState.on )
                      {
                          portTarget.IncomingCall();
                          args.CallStatus = CallState.NotRespond;
                       }
                  else
                       {
                           portInitiator.StopCall();
                           args.CallStatus = CallState.TargetPortBusy;
                      }
                  
              }
              else
              {
                  args.CallStatus = CallState.WrongNumber;

              }
          }
        public void AnswerCalling (object obj,EventArgs args )
        {
            Port port = (obj as Port);
            CallInfo callInfo = ActiveCalls.SingleOrDefault(p => p.PortTarget == port);
            callInfo.SetStartTimeCall();
            callInfo.CallProperties.CallStatus = CallState.ConnectionSucceded;
         }
        public void StopCall(object obj, EventArgs args)
        {
            Port port = (obj as Port);
            CallInfo callInfo = ActiveCalls.SingleOrDefault(p => p.PortInitiator == port || p.PortTarget == port);
            callInfo.SetStopTimeCall();

            if (callInfo.PortTarget == port)
           {
               callInfo.PortInitiator.StopCall();
               callInfo.CallProperties.CallStatus = CallState.finished;
           }
            else
            {
                callInfo.PortTarget.StopCall();
                callInfo.CallProperties.CallStatus = CallState.finished;
            }

           ActiveCalls.Remove(callInfo);

        }

        public void CreateClientConection(int newNumber , Client client)
        {

            if (unUsedPorts.Count == 0)
            {
                CreateUnUsedPort();
            }
            
            Port freePort = GetFreePort();
            if (CheckPhoneNumber(newNumber))
                {
                    Console.WriteLine(" This number is busy");
                    return ;
                }
            TelephoneNumber number = new TelephoneNumber(newNumber);
            Terminal terminal= new Terminal(number);
            CreateSubscriptions( freePort,terminal);
            client.Terminal = terminal;
            
        }

        public void ToStringStatusActiveCall()
        {
            foreach (var e in ActiveCalls)
            {
                Console.WriteLine("Initiator- {0} Target {1} status {2} ", e.CallProperties.Initiator, e.CallProperties.Target, e.CallProperties.CallStatus);
            }
        }

    }
}
