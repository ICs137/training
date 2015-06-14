using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class MarketingDepartment
    {
        
        private Dictionary<IPort, IClientInfo> Clients = new Dictionary<IPort, IClientInfo>();
        public void AddCallUser( CallInfo call )
        {
            IClientInfo client= Clients.FirstOrDefault(p => p.Key.);
        }



    }
 }
 