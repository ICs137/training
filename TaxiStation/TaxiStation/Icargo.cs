using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiStation
{
    public interface Icargo:Icar
    {
        float CargoMaxMass { get; }
        float CargoMaxVolume { get; }
    }
}
