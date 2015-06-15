using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class SimpleTariff:Tariff
    {
        private const int FixedPrepaidMinutes = 10;
        private readonly int minutePrice;
        public override int MinutePrice { get { return minutePrice; } }
        public SimpleTariff(int minutePrice  )
            {
               this.minutePrice = minutePrice;
            }
        public override int PrepaidMinutes 
            {
                get { return FixedPrepaidMinutes; }
            }
    }
}
