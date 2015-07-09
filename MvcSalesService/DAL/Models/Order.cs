using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Order
    {
        public int OrderId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public decimal Sum { get; set; }
        public int Manager_ManagerId { get; set; }
        public int Product_ProductId { get; set; }
        public int Customer_CustomerId { get; set; }

        public virtual Manager Manager { get; set; }
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
