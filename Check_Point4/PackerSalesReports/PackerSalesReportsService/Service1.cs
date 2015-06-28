using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace PackerSalesReportsService
{
    public partial class PackerSalesReportsService : ServiceBase
    {
        public PackerSalesReportsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
         BL.SalesService service=  new BL.SalesService();
        }

        protected override void OnStop()
        {

        }
    }
}
