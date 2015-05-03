using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetarySystem
{
    public   abstract class SpaceItem: ISpaceItem
    {



        public string Name
        {
            get;
            set;
        }

        public virtual Int32 Mass
        {
            get;
            set;
        }
    }
}
