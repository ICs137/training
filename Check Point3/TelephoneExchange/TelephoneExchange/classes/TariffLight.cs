using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class TariffLight:Tariff
     {

        const int FixedPricePerMinute = 10;
        public TariffLight (int prepaidMinutes)
            {
               this.prepaidMinutes = prepaidMinutes;
            }
        public override string Name { get; set; }
        public override int MinutePrice 
        {
            get { return FixedPricePerMinute; }
         
        }
        public override int PrepaidMinutes { get{return prepaidMinutes;} }
        private readonly int prepaidMinutes;

    }
}
