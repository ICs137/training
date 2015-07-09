using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DAL
{
    public class ManagerRepository:IModelRepository<Manager>
    {

        private Model.SaleContainer context = new Model.SaleContainer();
        private  Model.Manager ToEntity(Manager source)
        {
            return new Model.Manager() { ManagerId = source.ManagerId, Name = source.Name };
        }
        public static Manager ToObject(Model.Manager source)
        {
            return new Manager(){ ManagerId = source.ManagerId, Name = source.Name };
        }
        public void Add(Manager item)
        {
            var e = this.ToEntity(item);
            context.ManagerSet.Add(e);
        }
        public void Remove(Manager item)
        {
            var tempManager = context.ManagerSet.FirstOrDefault(x => x.Name == item.Name);
            if (tempManager != null)       
            {
                context.ManagerSet.Remove(tempManager);
            }
        }
        public void Update(Manager item)
        {
            var tempM = context.ManagerSet.FirstOrDefault(x => x.Name == item.Name);
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
                foreach (var u in this.context.ManagerSet)
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
