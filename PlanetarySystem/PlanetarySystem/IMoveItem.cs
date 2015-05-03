using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetarySystem
{
    public interface IMoveItem : ISpaceItem
    {
        Habitability Hab { get; set; }
        Double OrbitCircumference {get;}
    }
  


}
