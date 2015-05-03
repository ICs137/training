using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetarySystem
{
    public class AsteroidFamily : Asteroid, ICollection<Asteroid>
    {
        private ICollection<Asteroid> Asteroids = new List<Asteroid>();
      

        public  Int32 FullMass
        {
            get { return Asteroids.Aggregate(0, (seed, x) => seed + x.Mass); } //НЕ работает,загадка((
             
        }
        public void Add(Asteroid item)
        {
            Asteroids.Add(item);
        }

        public void Clear()
        {
            Asteroids.Clear();
        }

        public bool Contains(Asteroid item)
        {
            return Asteroids.Contains(item);
        }

        public void CopyTo(Asteroid[] array, int arrayIndex)
        {
            Asteroids.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return Asteroids.Count; }
        }

        public bool IsReadOnly
        {
            get { return Asteroids.IsReadOnly; }
        }

        public bool Remove(Asteroid item)
        {
            return Asteroids.Remove(item);
        }

        public IEnumerator<Asteroid> GetEnumerator()
        {
            return Asteroids.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
