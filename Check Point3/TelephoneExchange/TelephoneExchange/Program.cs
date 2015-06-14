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
            TelephoneExchange ATE = new TelephoneExchange();
            ATE.CreateUnUsedPort();
            ATE.CreateUnUsedPort();
            ATE.CreateUnUsedPort();
            ATE.CreateUnUsedPort();
            Client cl1 = new Client("Pavel");
            Client cl2 = new Client("Oleg");
            Client cl3 = new Client("Max");
            Client cl4 = new Client("dr.Who");
            ATE.CreateClientConection(123, cl1);
            ATE.CreateClientConection(1, cl2);
            ATE.CreateClientConection(1, cl2);
            ATE.CreateClientConection(13, cl3);
            ATE.CreateClientConection(42, cl4);


            cl1.Terminal.Call(42);
            cl4.Terminal.AnswerCall();
            cl4.Terminal.Call(13);
            cl3.Terminal.Call(1);
            cl2.Terminal.AnswerCall();
            cl4.Terminal.StopCall();

            ATE.ToStringStatusActiveCall();


        }
    }
}
