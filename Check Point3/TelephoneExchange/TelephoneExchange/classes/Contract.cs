using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class Contract
    {
        public DateTime LastChangeTariff { get; private set; }
        public ITariff ActualTariff { get; private set; }
        public Terminal Terminal { get; private set; }
        public void ChangeTariff ( ITariff item)
          {

            {
                if (LastChangeTariff.Month != DateTime.Now.Month)
                {
                    ActualTariff = item;
                    LastChangeTariff = DateTime.Now;
                }
            }

          }
        private readonly Client client;
        public Client Client
        {
            get { return client; }
        } 
        public readonly Guid id;
        public readonly DateTime dayOfSigning;
        public readonly DateTime expireDay;
        readonly int defaultDuration = 365;
        public Contract()
        {
            id = Guid.NewGuid();
            dayOfSigning = DateTime.Now.Date;
         
        }
        public Contract(Terminal terminal, ITariff tariff, TimeSpan duration, Client client)
            : this()
        {
            this.ActualTariff = tariff;
            Terminal = terminal;
            expireDay = dayOfSigning + duration;
            this.client = client;
        }

        public Contract(Terminal terminal, Client client,ITariff tariff)
            : this()
        {
            this.ActualTariff = tariff;
            this.client = client;
            Terminal = terminal;
            expireDay = dayOfSigning + new TimeSpan(defaultDuration, 0, 0, 0);
        }


    }
}
