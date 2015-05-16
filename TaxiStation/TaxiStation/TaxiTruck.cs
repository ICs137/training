using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiStation
{
    public class TaxiTruck:Car,Icargo
    {
        public float CargoMaxMass
        { get; set; }

        public float CargoMaxVolume
        { get; set; }

    }
}
