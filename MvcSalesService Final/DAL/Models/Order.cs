using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public System.DateTime OrderDate { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public int ManagerId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
