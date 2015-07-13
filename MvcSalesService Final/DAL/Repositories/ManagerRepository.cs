using System.Collections.Generic;
using System.Linq;
using Model;

namespace DAL
{
    public class ManagerRepository:IModelRepository<Manager>
    {

        private readonly SaleContainer _context ;

         public  ManagerRepository()
        {
           _context = new SaleContainer();
        }

         public ManagerRepository(SaleContainer context)
        {
            _context = context;
        } 
        private  Model.Manager ToEntity(Manager source)
        {
            return new Model.Manager { ManagerId = source.ManagerId, Name = source.Name };
        }
        public static Manager ToObject(Model.Manager source)
        {
            return new Manager { ManagerId = source.ManagerId, Name = source.Name };
        }
        public void Add(Manager item)
        {
            var e = ToEntity(item);
            _context.ManagerSet.Add(e);
        }
        public void Remove(Manager item)
        {
            var tempManager = _context.ManagerSet.FirstOrDefault(x => x.Name == item.Name);
            if (tempManager != null)       
            {
                _context.ManagerSet.Remove(tempManager);
            }
        }
        public void Update(Manager item)
        {
            var tempM = _context.ManagerSet.FirstOrDefault(x => x.Name == item.Name);
            if (tempM == null)
            {
                Add(item);
                SaveChanges();
            }
            
        }
        public IEnumerable<Manager> Items
        {
            get
            {
                List<Manager> templist = new List<Manager>();
                foreach (var u in _context.ManagerSet)
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
