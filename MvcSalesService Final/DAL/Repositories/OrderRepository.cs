using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using DAL.classes;
using Model;

namespace DAL
{
    public class OrderRepository : IModelRepository<Order>
    {
        private readonly SaleContainer _context;

        public  OrderRepository()
        {
           _context = new SaleContainer();
        }

        public OrderRepository(SaleContainer context)
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
                    return new Model.Order
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
                    return new Model.Order
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
            return new Order
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
            var e = ToEntity(item);
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
                foreach (var u in _context.OrderSet)
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

        public IEnumerable<Order> GetSomeOrders(int skip, int take, out int count)
        {
            IQueryable<Model.Order> templist = _context.OrderSet.OrderBy(x=>x.OrderId).Skip(skip).Take(take);
            count = _context.OrderSet.Count();
            List<Order> tempOrderList = new List<Order>();
            foreach (var u in templist)
            {
                tempOrderList.Add(ToObject(u));
               
            }
             return tempOrderList;
        }

        public IEnumerable<Order> GetSomeFilterOrders(int skip, int take, IFilters filters  , out int count)
        {

            IQueryable<Model.Order> oredrlist = _context.OrderSet.OrderBy(x=>x.OrderId);

            if (filters.FilterManagerId != 0)
            {

                Model.Manager firstOrDefault = _context.ManagerSet.FirstOrDefault(x => x.ManagerId == filters.FilterManagerId);
                if (firstOrDefault != null)
                {
                    IQueryable<Model.Order> temList = oredrlist.Where(x => x.Manager.Name == firstOrDefault.Name);
                    oredrlist = temList;
                }

            }

            if (filters.FilterCustomerId != 0)
            {
                Model.Customer firstOrDefault =
                    _context.CustomerSet.FirstOrDefault(x => x.CustomerId == filters.FilterCustomerId);
                   
                if (firstOrDefault != null)
                {
                    IQueryable<Model.Order> temList = oredrlist.Where(x => x.Customer.Name == firstOrDefault.Name);
                    oredrlist = temList;
                }
            }

            if (filters.FilterProductId != 0)
            {
                Model.Product firstOrDefault = _context.ProductSet.FirstOrDefault(x => x.ProductId == filters.FilterProductId);
                if (firstOrDefault != null)
                {
                    IQueryable<Model.Order> temList = oredrlist.Where(x => x.Product.Description == firstOrDefault.Description);
                    oredrlist = temList;
                }
            }

            if (filters.FilterDateMin!=new DateTime())
            {
                IQueryable<Model.Order> temList = oredrlist.Where(x => x.OrderDate >= filters.FilterDateMin);
                oredrlist = temList;
                
            }
            if (filters.FilterDateMax != new DateTime())
            {
                IQueryable<Model.Order> temList = oredrlist.Where(x => x.OrderDate <= filters.FilterDateMax);
                oredrlist = temList;
            }


            if (filters.FiLterPriceMin!=0)
            {
                IQueryable<Model.Order> temList = oredrlist.Where(x => x.Sum >= filters.FiLterPriceMin);
                oredrlist = temList;
            }
            if (filters.FilterPriceMax !=0)
            {
                 IQueryable<Model.Order> temList = oredrlist.Where(x => x.Sum <= filters.FilterPriceMax);
                oredrlist = temList;
            }
            List<Order> tempOrderList = new List<Order>();
            foreach (var u in oredrlist.Skip(skip).Take(take))
            {
                tempOrderList.Add(ToObject(u));
            }
            count = tempOrderList.Count;
            return tempOrderList;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
