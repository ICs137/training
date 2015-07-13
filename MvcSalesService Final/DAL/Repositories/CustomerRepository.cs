using System.Collections.Generic;
using System.Linq;
using Model;

namespace DAL
{
    public class CustomerRepository:IModelRepository<Customer>
    {
        private readonly SaleContainer _context;


         public  CustomerRepository()
        {
           _context = new SaleContainer();
        }

         public CustomerRepository(SaleContainer context)
        {
            _context = context;
        } 
        
        private Model.Customer ToEntity(Customer source)
        {
            return new Model.Customer { CustomerId = source.CustomerId, Name = source.Name };
        }
        public static Customer ToObject(Model.Customer source)
        {
            return new Customer { CustomerId = source.CustomerId, Name = source.Name };
        }
        public void Add(Customer item) 
        {
            var e = ToEntity(item);
            _context.CustomerSet.Add(e);
        }
        public void Remove(Customer item)
        {
            var tempCustomer = _context.CustomerSet.FirstOrDefault(x => x.Name == item.Name);
            if (tempCustomer != null)
            {
                _context.CustomerSet.Remove(tempCustomer);
            }
        }
        public void Update(Customer item)
        {
            var tempCustomer = _context.CustomerSet.FirstOrDefault(x => x.Name == item.Name);
            if (tempCustomer == null)
            {
                Add(item);
                SaveChanges();
            }
        }
        public IEnumerable<Customer> Items
        {
            get
            {
                List<Customer> templist = new List<Customer>();
                foreach (var u in _context.CustomerSet)
                {
                    templist.Add(ToObject(u));
                }
                return templist;
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
