using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class MarketingDepartment:IMarketingDepartment
    {

        private Dictionary<Port, Contract> clientContract = new Dictionary<Port, Contract>();
        public Dictionary<Port, Contract> ClientContract
        {
            get { return clientContract; }
            set { clientContract = value; }
        }
        public Contract GetContract(Port portInitiator)
        {
           return  ClientContract[portInitiator];
        }
        private ITariff GetUserTariff( Port portInitiator)
        {
            return GetContract(portInitiator).ActualTariff;
        }
        private Dictionary<Contract, List<CallInfo>> calls = new Dictionary<Contract, List<CallInfo>>();
        public Dictionary<Contract, List<CallInfo>> Calls
        {
            get { return calls; }
            set { calls = value; }
        }
        public void AddCalls(Contract contract, CallInfo callinfo)
        {
            if (!calls.ContainsKey(contract))
                {
                    calls.Add(contract, new List<CallInfo>(){ callinfo });
                }
            else
                {
                    calls[contract].Add(callinfo);
                }

        }
        public int GetCostCall( CallInfo callinfo)
        {
           Contract contract= GetContract(callinfo.PortInitiator);
           Double listCallsDurationSPerMonth = Calls[contract].Where(p => p.StartTimeCall > DateTime.Now.AddMonths(-1)).Sum(x => x.DurationCall.TotalMinutes);
            
            if ( contract.ActualTariff.PrepaidMinutes > listCallsDurationSPerMonth)
            {
                return 0;
            }
            else
            {
                return (Int32)(callinfo.DurationCall.TotalMinutes * contract.ActualTariff.MinutePrice);
            }
        }
        public void GetReport(object obj, ReportEventArgs args)
        {
           int count = Calls[args.contract].Count - 1;
           Contract contract = args.contract;
           args.Report = string.Empty;
              if (count<0)
              {
                  args.Report = "call list is empty";
                  return;

              }

            if (args.Queries==Query.LastCall)
                {
                                      
                  args.Report = String.Format(" addressee {0}, duration {1}, cost {2}", Calls[contract][count].CallProperties.Target, Calls[contract][count].DurationCall,
                            Calls[contract][count].CostCall);
                    return;
                }
        
           
                var listCallsPerMonth = Calls[contract].Where(p => p.StartTimeCall > DateTime.Now.AddMonths(-1));

                string report = string.Empty;

                foreach (var e in listCallsPerMonth)
                {
                    String.Concat(args.Report, String.Format(" addressee {0}, duration {1}, cost {2}", e.CallProperties.Target, e.DurationCall, e.CostCall));
                }
                return;
           
         }
        public void AttachClient(Client client)
            {
                client.Report -= GetReport;
                client.Report += GetReport;
            }
        public void UnAttachClient(Client client)
            {
                client.Report -= GetReport;
           
            }

    }
 }
 