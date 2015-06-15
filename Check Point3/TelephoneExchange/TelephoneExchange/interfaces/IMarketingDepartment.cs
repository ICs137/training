using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    interface IMarketingDepartment
    {
         Dictionary<Port, Contract> ClientContract{get;set;}
         void AddCalls(Contract contract, CallInfo callinfo);
         Contract GetContract(Port portInitiator);
         int GetCostCall(CallInfo callinfo);
         void AttachClient(Client client);
         void UnAttachClient(Client client);
    }
}
