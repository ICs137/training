using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_2
{
    class Item
    {

        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        Int32 price;
        public Int32 Price
        {
            get { return price; }
            set { price = value; }
        }
        Int32 amt;
        public Int32 Amt
        {
            get { return amt; }
            set { amt = value; }
        }


        public Item(string nm, Int32 pr, Int32 am)
        {
            Name = nm;
            Price = pr;
            Amt = am;
        }

        public Int32 in_total()
        {
            return price * amt;
        }

    }
}
