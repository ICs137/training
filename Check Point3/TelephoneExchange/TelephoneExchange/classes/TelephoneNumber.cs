using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public struct TelephoneNumber
    {
        private readonly int _phoneNumber;
        public int PhoneNumber
        {
            get { return _phoneNumber; }
        }
        public TelephoneNumber(int number)
        {
            _phoneNumber = number;
        }
    }
}
