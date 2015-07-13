using System;
using System.Collections.Generic;
using DAL;

namespace MvcSalesService.Models
{
    public class OrderListViewModel : DAL.classes.Filters
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
   
    }
}