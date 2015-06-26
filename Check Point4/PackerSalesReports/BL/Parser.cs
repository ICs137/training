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
        private readonly string _nameManager;
        public string NameManager
        {
            get { return _nameManager; }
        } 
        public Parser(string name)
            {
                _nameManager = name;
            }
        public string[] GetWords(string line) // split a string into words
        {
            string[] words = line.Split(punctuationSeparators, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }

        public ItemOrder GetOrder( string line)
        {
            string customer;
            string product;
            DateTime date;
            decimal pricce;
            string[] words = this.GetWords(line);
            if (words.Length <4)
                {
                    return null;
                }
            DateTime.TryParseExact(words[0], @"DDMMYYYY", null, DateTimeStyles.None, out date);
            customer = words[1];
            product = words[2];
            Decimal.TryParse(words[3], out pricce);
            return new ItemOrder(customer, NameManager, product, date, pricce);
        }

    }
}
