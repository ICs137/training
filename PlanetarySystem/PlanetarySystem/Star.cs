using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetarySystem
{
    public class Star : SpaceItem, IStaticItem
    {
        public bool NuclearFusion { get; set; }
        public double SolarLuminosity { get; set; }
    } 
}
