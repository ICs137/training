using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcSalesService.Models
{
    public class PagingInfo
    {
        public PagingInfo(IEnumerable<object> list  )
        {
            TotalItems = list.Count();
        }
        public PagingInfo()
        {
        }

        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}