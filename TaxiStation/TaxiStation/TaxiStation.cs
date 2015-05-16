using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiStation
{
    public class TaxiStation:ICollection<Icar>
    {

        private ICollection<Icar> cars = new List<Icar>();



        public void Add(Icar item)
        {
            cars.Add(item);
        }

        public void Clear()
        {
            cars.Clear();
        }

        public bool Contains(Icar item)
        {
            return cars.Contains(item);
        }

        public void CopyTo(Icar[] array, int arrayIndex)
        {
            cars.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return cars.Count(); }
        }

        public bool IsReadOnly
        {
            get { return cars.IsReadOnly; }
        }

        public bool Remove(Icar item)
        {
            return cars.Remove(item) ;
        }

        public IEnumerator<Icar> GetEnumerator()
        {
           return cars.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            t return this.GetEnumerator();
        }
    }
}
