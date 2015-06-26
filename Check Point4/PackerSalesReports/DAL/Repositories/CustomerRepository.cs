using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CustomerRepository:IModelRepository<Customer>
    {
        private Model.SaleContainer context = new Model.SaleContainer();
        private Model.Customer ToEntity(Customer source)
        {
            return new Model.Customer() { CustomerId = source.CustomerId, Name = source.Name };
        }
        public static Customer ToObject(Model.Customer source)
        {
            return new Customer() { CustomerId = source.CustomerId, Name = source.Name };
        }
        public void Add(Customer item) 
        {
            var e = this.ToEntity(item);
            context.CustomerSet.Add(e);

        }
        public void Remove(Customer item)
        {
            var tempCustomer = context.CustomerSet.FirstOrDefault(x => x.Name == item.Name);
            if (tempCustomer != null)
            {
                context.CustomerSet.Remove(tempCustomer);
            }
        }
        public void Update(Customer item)
        {
            var tempCustomer = context.CustomerSet.FirstOrDefault(x => x.Name == item.Name);
            if (tempCustomer == null)
            {
                Add(item);
            }
        }
        public IEnumerable<Customer> Items
        {
            get
            {
                List<Customer> templist = new List<Customer>();
                foreach (var u in this.context.CustomerSet)
                {
                    templist.Add(ToObject(u));
                }
                return templist;
            }
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
