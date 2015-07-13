using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class OrderRepository : IModelRepository<Order>
    {
        private readonly Model.SaleContainer _context;

        public  OrderRepository()
        {
           _context = new Model.SaleContainer();
        }

        public OrderRepository(Model.SaleContainer context)
        {
            _context = context;
        }

        private Model.Order ToEntity(Order source)
        {
            if (source.ManagerId == 0 || source.CustomerId == 0 || source.ProductId == 0)
            {
                var tempManager = _context.ManagerSet.FirstOrDefault(x => x.Name == source.Manager.Name);
                var tempCustomer = _context.CustomerSet.FirstOrDefault(x => x.Name == source.Customer.Name);
                var tempProduct = _context.ProductSet.FirstOrDefault(x => x.Description == source.Product.Description);
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
            else
            {
                var tempManager = _context.ManagerSet.FirstOrDefault(x => x.ManagerId == source.ManagerId);
                var tempCustomer = _context.CustomerSet.FirstOrDefault(x => x.CustomerId == source.CustomerId);
                var tempProduct = _context.ProductSet.FirstOrDefault(x => x.ProductId == source.ProductId);
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
            
        }
        public Order ToObject(Model.Order source)
        {
            if (source == null)
            {
                return null;
            }
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
            if(e==null)
                {
                    return;
                }
            _context.OrderSet.Add(e);
        }
        public void Remove(Order item)
        {
            var tempOrder = _context.OrderSet.FirstOrDefault
                (
                    x => x.Manager.Name==item.Manager.Name && 
                    x.OrderDate==item.OrderDate && 
                    x.Sum==item.Sum && 
                    x.Product.Description==item.Product.Description && 
                    x.Customer.Name==item.Customer.Name
                );
            if (tempOrder != null)
            {
                _context.OrderSet.Remove(tempOrder);
            }
        }
        public void AddWithValidate(Order item)
        {
            var tempOrder = _context.OrderSet.FirstOrDefault
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

        public void Update(Order item)
        {
            var tempOrderEntity = _context.OrderSet.FirstOrDefault(x => x.OrderId == item.OrderId);
            if (tempOrderEntity == null)
            {
                return;
            }
            var tempOrder= ToEntity(item);
            if (tempOrder==null)
            {
                return;
            }
            tempOrderEntity.Customer = tempOrder.Customer;
            tempOrderEntity.Manager = tempOrder.Manager;
            tempOrderEntity.OrderDate = tempOrder.OrderDate;
            tempOrderEntity.Product = tempOrder.Product;
            tempOrderEntity.Sum = tempOrder.Sum;

        }

        public void Remove(int id)
        {
            var tempOrder = _context.OrderSet.FirstOrDefault(x => x.OrderId == id);
            if (tempOrder != null)
            {
                _context.OrderSet.Remove(tempOrder);
            }
        }

        public IEnumerable<Order> Items
        {
            get
            {
                List<Order> templist = new List<Order>();
                foreach (var u in this._context.OrderSet)
                    {
                        templist.Add (ToObject(u));
                    }
                return templist;
            }
        }

        public Order GetItem(int id)
        {
            Order tempOrder = ToObject(_context.OrderSet.FirstOrDefault(x => x.OrderId == id));
            return tempOrder;
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
