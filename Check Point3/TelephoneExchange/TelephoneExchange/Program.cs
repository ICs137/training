using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            MarketingDepartment marketingDepartment = new MarketingDepartment();
            TelephoneExchange ATE = new TelephoneExchange(marketingDepartment);
            
            Client cl1 = new Client("Pavel");
            Client cl2 = new Client("Oleg");
            Client cl3 = new Client("Max");
            Client cl4 = new Client("dr.Who");
            ITariff light = new TariffLight(10);
            ITariff light2 = new TariffLight(11);
            ITariff light3 = new TariffLight(14);


            ATE.CreateNewContract(123, cl1, light);
            ATE.CreateNewContract(1, cl2, light2);
            ATE.CreateNewContract(13, cl3, light);
            ATE.CreateNewContract(42, cl4, light3);


            cl1.Contracts[0].Terminal.Call(13);
            cl3.Contracts[0].Terminal.AnswerCall();
            cl1.Contracts[0].Terminal.StopCall();
            cl1.GetReport(Query.LastCall, cl1.Contracts[0]);

           ATE.ToStringStatusActiveCall();


        }
    }
}
