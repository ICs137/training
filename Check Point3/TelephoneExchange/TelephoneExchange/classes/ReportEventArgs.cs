using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class ReportEventArgs:EventArgs
    {
        public Query Queries { get; set; }
        public string Report { get; set; }
        public Contract contract { get; set;}
    }
}
