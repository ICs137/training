using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class Client:IClientInfo
    {
        private List<Contract> contracts = new List<Contract>();
        public List<Contract> Contracts
        {
            get { return contracts; }
            set { contracts = value; }
        }
        private readonly string name;

        public string Name
        {
          get { return name; }  
        } 





    }
}
