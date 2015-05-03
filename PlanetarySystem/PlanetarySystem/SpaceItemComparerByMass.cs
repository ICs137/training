using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetarySystem
{
    public class SpaceItemComparerByMass:IComparer<ISpaceItem>
    {

        public int Compare(ISpaceItem x, ISpaceItem y)
        {
            if (x != null && y != null)
            {
                if (x.Mass > y.Mass)
                {
                    return 1;
                }
                else
                {
                    return (x.Mass == y.Mass) ? 0 : -1;
                }
            }
            else
            {
                return (y == null && x == null) ? 0 : (x != null) ? 1 : -1;
            }
        }



    }
}
