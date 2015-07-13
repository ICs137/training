using System.Collections.Generic;
using System.Linq;
using Model;

namespace DAL
{
    public class ProductRepository:IModelRepository<Product>
    {
        private readonly SaleContainer _context;

        public ProductRepository()
        {
           _context = new SaleContainer();
        }


        public ProductRepository(SaleContainer context)
        {
            _context = context;
        }



        private Model.Product ToEntity(Product source)
        {
            return new Model.Product { ProductId = source.ProductId, Description = source.Description };
        }
        public static Product ToObject(Model.Product source)
        {
            return new Product { ProductId = source.ProductId, Description = source.Description };
        }
        public void Add(Product item)
        {
            var e = ToEntity(item);
            _context.ProductSet.Add(e);
        }
        public void Remove(Product item)
        {
            var tempProduct = _context.ProductSet.FirstOrDefault(x => x.Description == item.Description);
            if (tempProduct != null)
            {
                _context.ProductSet.Remove(tempProduct);
            }
        }
        public void Update(Product item)
        {
            var tempProduct = _context.ProductSet.FirstOrDefault(x => x.Description == item.Description);
            if (tempProduct == null)
            {
                Add(item);
                SaveChanges();
            }
        }
        public IEnumerable<Product> Items
        {
            get
            {
                List<Product> templist = new List<Product>();
                foreach (var u in _context.ProductSet)
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
