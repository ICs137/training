using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiStation
{
    public interface Ipassengert:Icar
    {

        Int16 CapacityPassengert { get; }
    }
}
