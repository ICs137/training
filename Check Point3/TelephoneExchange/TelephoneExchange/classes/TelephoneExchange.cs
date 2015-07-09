using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TelephoneExchange
{
    public class TelephoneExchange:ITelephoneExchange
    {
        private readonly IMarketingDepartment _marketingDepartment;
        internal IMarketingDepartment MarketingDepartment
        {
            get { return _marketingDepartment; }
        } 
        public TelephoneExchange( MarketingDepartment marketingDepartment )
        {
            this._marketingDepartment = marketingDepartment;
        }
        private List<CallInfo> activeCalls = new List<CallInfo>();
        public List<CallInfo> ActiveCalls
            {
              get { return activeCalls; }
              set { activeCalls = value; }
            }
        private List<Subscriptions> subscriptions = new List<Subscriptions>();
        public List<Subscriptions> Subscriptions
        {
            get { return subscriptions; }
            set { subscriptions = value; }
        }
        private Queue<Port> unUsedPorts = new Queue<Port>();
        private Queue<Terminal> unUsedTerminals = new Queue<Terminal>();
        private List<CallInfo> callLog = new List<CallInfo>();
        public List<CallInfo> CallLog
        {
            get { return callLog; }
            set { callLog = value; }
        }
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
        private  void CreateUnUsedPort()
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
                if ( temp!=null)
                {
                    return temp.Port;
                }
                return null;
            }

        # region event handling calls
        public void StartCall(object obj,CallingEventArgs args)
          { 
              
              IPort portTarget = FindPort(args.Target);
              Port portInitiator =  (obj as Port);
              CallInfo thisCallInfo = new CallInfo(args) { PortInitiator = portInitiator, PortTarget = portTarget };
              CallLog.Add(thisCallInfo);
              Contract contract=  _marketingDepartment.GetContract(portInitiator);
              _marketingDepartment.AddCalls(contract, thisCallInfo);
              if (portTarget == null)
              {
                  portInitiator.StopCall();
                  thisCallInfo.CallProperties.CallStatus = CallState.WrongNumber;
                  return;
              }
              
               if(  portTarget==portInitiator)
               {
                   portInitiator.StopCall();
                   thisCallInfo.CallProperties.CallStatus = CallState.YourPortBusy;
                   return;
               }
             
              ActiveCalls.Add(thisCallInfo);
       
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
            callInfo.CallProperties.CallStatus = CallState.ConnectionSuccessful;
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

            int cost = MarketingDepartment.GetCostCall(callInfo);
            callInfo.CostCall = cost;
            ActiveCalls.Remove(callInfo);
        }
        #endregion

        public void CreateNewContract(int newNumber, Client client, ITariff tarif)
        {

            if (unUsedPorts.Count == 0)
            {
                CreateUnUsedPort();
            }

            Port freePort = GetFreePort();
            if (CheckPhoneNumber(newNumber))
            {
                Console.WriteLine(" This number is busy");
                return;
            }
            TelephoneNumber number = new TelephoneNumber(newNumber);
            Terminal terminal = new Terminal(number);
            CreateSubscriptions(freePort, terminal);

            Contract contract = new Contract(terminal, client, tarif);
            MarketingDepartment.ClientContract.Add(freePort, contract);
            client.Contracts.Add(contract);
            MarketingDepartment.AttachClient(client);

        }//the creation of a contract and activation services
        public void ToStringStatusActiveCall()
        {
            Console.WriteLine("log Cals");

            foreach (var e in CallLog)
            {
                Console.WriteLine("Initiator- {0} Target {1} status {2} duration {3}   ", e.CallProperties.Initiator, e.CallProperties.Target, e.CallProperties.CallStatus,e.DurationCall);
            }
            Console.WriteLine();
            Console.WriteLine("Active Calls right now");
            foreach (var e in ActiveCalls)
            {
                Console.WriteLine("Initiator- {0} Target {1} status {2} ", e.CallProperties.Initiator, e.CallProperties.Target, e.CallProperties.CallStatus);
            }


        }






    }
}
