using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class Client
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
        public Client (string name )
        {
            this.name = name;
        }
        public ReportEventArgs report= new ReportEventArgs();
        public event EventHandler<ReportEventArgs> Report;
        protected virtual void OnReport( Query query,Contract contract)
        {
            report.contract = contract;
            report.Queries = query;
            if (Report!=null)
            {
                Report(this, report);
            }
        }
        public void GetReport(Query query,Contract contract )
            {
                OnReport(query, contract);
            }

    }
}
