using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public struct TelephoneNumber
    {
        public int PhoneNumber { get; private set; }
        public TelephoneNumber(int number)
        {
            PhoneNumber = number;
        }
    }
}
