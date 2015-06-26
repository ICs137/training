using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
