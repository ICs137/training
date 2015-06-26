using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class ItemOrder
    {
        private readonly string _customer;

        public string Customer
        {
            get { return _customer; }
        }
        private readonly string _manager;
        public string Manager
        {
            get { return _manager; }
        }
        private readonly string _product;
        public string Product
        {
            get { return _product; }
        }
        private readonly DateTime _orderDate;
        public DateTime OrderDate
        {
            get { return _orderDate; }
        }
        private readonly Decimal _price;
        public Decimal Price
        {
            get { return _price; }
        }

        public ItemOrder( string customer,string manager, string product,DateTime date,Decimal pricce)
        {
            _customer = customer;
            _manager = manager;
            _product = product;
            _orderDate = date;
            _price = pricce;

        }


    }


}
