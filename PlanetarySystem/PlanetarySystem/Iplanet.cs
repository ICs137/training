using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetarySystem
{
    public interface IPlanet:IMoveItem,INuclearFusion
    {

       Double AtmospherePressure { get; }

    }
}
