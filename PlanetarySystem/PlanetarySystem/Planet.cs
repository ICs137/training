using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetarySystem
{
    public class Planet : Asteroid, IPlanet,ICollection<ISatellite>
    {
        public double AtmospherePressure
        {
            get;
            set;
        }

        public int SatelliteCount
        {
            get;
            set;
        }

        public bool NuclearFusion
        {
            get;
            set;
        }

        public double SolarLuminosity
        {
            get;
            set;
        }


        private ICollection<ISatellite> satellites = new List<ISatellite>();

        public Double FullMass
        {
            get { return this.Mass+ satellites.Aggregate((Double)0, (seed, x) => seed + x.Mass); }

        }

        public void Add(ISatellite item)
        {
          satellites  .Add(item);
        }

        public void Clear()
        {
           satellites .Clear();
        }

        public bool Contains(ISatellite item)
        {
           return satellites.Contains(item);
        }

        public void CopyTo(ISatellite[] array, int arrayIndex)
        {
            CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get {return satellites.Count; }
        }

        public bool IsReadOnly
        {
            get {return satellites.IsReadOnly; }
        }

        public bool Remove(ISatellite item)
        {
          return  satellites .Remove(item);
        }

        public IEnumerator<ISatellite> GetEnumerator()
        {
            return satellites.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
