using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace MvcSalesService.Models
{
    public class OrderListViewModel
    {
        public OrderListViewModel(IEnumerable<Order> orders)
        {
            Orders = orders;
        }
        public OrderListViewModel()
        {
            PagingInfo = new PagingInfo();
        }
        public IEnumerable<Order> Orders { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public int FilterManagerId { get; set; }
        public int FilterCustomerId { get; set; }
        public int FilterProductId { get; set; }
        public int FiLterPriceMin { get; set; }
        public int FilterPriceMax { get; set; }
        public DateTime FilterDateMin { get; set; }
        public DateTime FilterDateMax { get; set; }

    }
}