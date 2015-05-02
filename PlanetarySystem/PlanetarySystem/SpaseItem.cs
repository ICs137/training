using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetarySystem
{
    public   abstract class SpaceItem: ISpaceItem
    {


       public string Name  { get; }
       public Double Mass  { get; }
        
    }
}
