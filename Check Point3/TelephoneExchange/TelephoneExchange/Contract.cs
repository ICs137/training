using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class Contract
    {
        public DateTime LastChangeTariff { get; private set; }
        public Tariff ActualTariff { get; private set; }
        public Terminal Terminal { get; private set; }
        public void ChangeTariff ( Tariff item)
          {

            {
                if (LastChangeTariff.Month != DateTime.Now.Month)
                {
                    ActualTariff = item;
                    LastChangeTariff = DateTime.Now;
                }

            }

          }
                
        public readonly Guid id;
        public readonly DateTime dayOfSigning;
        public readonly DateTime expireDay;
        

        public Contract()
        {
            id = Guid.NewGuid();
            dayOfSigning = DateTime.Now.Date;
            expireDay = dayOfSigning + new TimeSpan(365, 0, 0, 0);

        }

        public Contract( Terminal terminal, Tariff tariff)
            : this()
        {
            this.ActualTariff = tariff;
            Terminal = terminal;
        }




    }
}
