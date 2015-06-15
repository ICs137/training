using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public interface ITariff
    {
        int  MinutePrice  {get;}
        int PrepaidMinutes { get;}

    }
}
