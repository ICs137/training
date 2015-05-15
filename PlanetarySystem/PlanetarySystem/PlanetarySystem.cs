using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetarySystem
{
    public class PlanetarySystem :ICollection<ISpaceItem>
        
    {


        private ICollection<ISpaceItem> spaceItems = new List<ISpaceItem>();

        #region ICollection<ISpaceItem>
        public void Add(ISpaceItem item)
        {
            spaceItems.Add(item);
        }

        public void Clear()
        {
            spaceItems.Clear();
        }

        public bool Contains(ISpaceItem item)
        {
            return spaceItems.Contains(item);
        }

        public void CopyTo(ISpaceItem[] array, int arrayIndex)
        {
            spaceItems.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return spaceItems.Count; }
        }

        public bool IsReadOnly
        {
            get {return spaceItems.IsReadOnly;}
        }

        public bool Remove(ISpaceItem item)
        {
         return   spaceItems.Remove(item); ;
        }

        public IEnumerator<ISpaceItem> GetEnumerator()
        {
            return spaceItems.GetEnumerator(); ;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
        protected void Sort(IComparer<ISpaceItem> comparer)
        {
            var newList = spaceItems.ToList();
            newList.Sort(comparer);
            spaceItems = newList;
        }

        public void SortByMass()
        {
            this.Sort(new SpaceItemComparerByMass());
        }

        public IEnumerable<ISpaceItem> GetSpaceItem(Double minMass, Double maxMass)
        {
            foreach (var i in spaceItems)
            {
                if (i.Mass >= minMass && i.Mass <= maxMass)
                {
                    yield return i;
                }
            }
        }
            public IEnumerable<ISpaceItem> Find (string Nam)
        {

            foreach (var i in spaceItems)
            {
                if (i.Name==Nam)
                {
                    yield return i;
                }
            }



        }




        internal void Add(AsteroidFamilyBuilder asteroidFamilyBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
