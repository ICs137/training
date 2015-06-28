using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class ItemOrderModels
    {
        private readonly DAL.Customer _customer;
        public DAL.Customer Customer
        {
            get { return _customer; }
        }
        private readonly DAL.Manager _manager;
        public DAL.Manager Manager
        {
            get { return _manager; }
        }
        private readonly DAL.Order _order;
        public DAL.Order Order
        {
            get { return _order; }
        }
        private readonly DAL.Product _product;
        public DAL.Product Product
        {
            get { return _product; }
        } 
        public ItemOrderModels(DAL.Customer _customer,DAL.Manager _manager,DAL.Order _order,DAL.Product _product)
            {
                this._customer = _customer;
                this._manager = _manager;
                this._order = _order;
                this._product = _product;

            }
              
    }
}
