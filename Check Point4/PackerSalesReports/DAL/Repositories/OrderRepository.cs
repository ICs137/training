using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class OrderRepository : IModelRepository<Order>
    {
        private Model.SaleContainer context = new Model.SaleContainer();
        private Model.Order ToEntity(Order source)
        {
            var tempManager = context.ManagerSet.FirstOrDefault(x => x.Name == source.Manager.Name);
            var tempCustomer = context.CustomerSet.FirstOrDefault(x => x.Name == source.Customer.Name);
            var tempProduct = context.ProductSet.FirstOrDefault(x => x.Description == source.Product.Description);
            if (tempManager != null && tempCustomer != null && tempProduct != null)
                {
                return new Model.Order() 
                    {
                        OrderId = source.OrderId,
                        Manager = tempManager, 
                        Customer = tempCustomer,
                        Product = tempProduct,
                        OrderDate = source.OrderDate,
                        Sum = source.Sum 
                    };
                 }
             return null;
                   
             }
        public Order ToObject(Model.Order source)
        {
            return new Order()
            { 
                OrderId = source.OrderId,
                Sum=source.Sum,
                OrderDate=source.OrderDate,
                Product= ProductRepository.ToObject(source.Product),
                Customer= CustomerRepository.ToObject(source.Customer),
                Manager=ManagerRepository.ToObject (source.Manager)
            };
        }
        public void Add(Order item)
        {
            var e = this.ToEntity(item);
            context.OrderSet.Add(e);
        }
        public void Remove(Order item)
        {
            var tempOrder = context.OrderSet.FirstOrDefault
                (
                    x => x.Manager.Name==item.Manager.Name && 
                    x.OrderDate==item.OrderDate && 
                    x.Sum==item.Sum && 
                    x.Product.Description==item.Product.Description && 
                    x.Customer.Name==item.Customer.Name
                );
            if (tempOrder != null)
            {
                context.OrderSet.Remove(tempOrder);
            }
        }
        public void Update(Order item)
        {
            var tempOrder = context.OrderSet.FirstOrDefault
                (
                    x => x.Manager.Name == item.Manager.Name &&
                    x.OrderDate == item.OrderDate &&
                    x.Sum == item.Sum &&
                    x.Product.Description == item.Product.Description &&
                    x.Customer.Name == item.Customer.Name
                );
            if (tempOrder == null)
            {
                Add(item);
            }
        }
        public IEnumerable<Order> Items
        {
            get
            {
                List<Order> templist = new List<Order>();
                foreach (var u in this.context.OrderSet)
                    {
                        templist.Add (ToObject(u));
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
