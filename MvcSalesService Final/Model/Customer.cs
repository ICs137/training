//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Model
{
    public partial class Customer
    {
        public Customer()
        {
            this.Order = new HashSet<Order>();
        }
    
        public int CustomerId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Order> Order { get; set; }
    }
}
