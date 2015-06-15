using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public abstract class Tariff:ITariff
    {
        public virtual string Name { get;  set; }
        public virtual int MinutePrice { get; set; }
        public virtual int PrepaidMinutes { get; set; }
        
    }
}
