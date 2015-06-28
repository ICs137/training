using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BL
{
    public class Parser
    {
        private readonly string[] punctuationSeparators = new string[] {";"};
        public string[] GetWords(string line) // split a string into words
        {
            string[] words = line.Trim().Split(punctuationSeparators, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }
        public ItemOrder GetOrder(string line, string nameManager)
        {
            string customer;
            string product;
            DateTime tempDate;
            decimal pricce;
            string[] words = this.GetWords(line);
            if (words.Length <4)
                {
                    return null;
                }
            if  (!DateTime.TryParseExact(words[0].Trim(), @"ddMMyyyy", null, DateTimeStyles.None, out tempDate))
                {
                    return null;
                }
            customer = words[1];
            product = words[2];
            if(!Decimal.TryParse(words[3], out pricce))
                {
                    return null;
                }
            DateTime date = tempDate.Date;
            return new ItemOrder(customer, nameManager, product, date, pricce);
        }

    }
}
