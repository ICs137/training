using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetarySystem
{
    public class Satellite : Asteroid, ISatellite
    {

        public bool Artificially
        {
            get;
            set;
        }
    }
}
