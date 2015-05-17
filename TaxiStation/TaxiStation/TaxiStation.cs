using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiStation
{
    public class TaxiStation:ICollection<Icar>
    {

        private ICollection<Icar> cars = new List<Icar>();


        #region Collection
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
            return this.GetEnumerator();
        }
        #endregion


        Dictionary<String, Func<Icar, object>> sortDict =
                                      new Dictionary<string, Func<Icar, object>>()
        {
            {"maxSpeed", x => x. MaxSpeed},
            
            {"fuelconsumption", x => x.FuelConsumption},
            {"manufactureddate", x => x.ManufacturedDate},
            {"mass", x => x.Mass},
            
        };

        public void SortWithDict(string a)
        {

            a = a.ToLower();
            a = new string(a.ToCharArray().Where(x => !Char.IsWhiteSpace(x)).ToArray());

            if (sortDict.ContainsKey(a))
            {
                cars = cars.OrderBy(sortDict[a]).ToList();
            }
            else
            {
               // cars = cars.OrderBy(x => x.ModelName).ToList();
            }


        }



    }
}
