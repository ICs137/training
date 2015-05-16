using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiStation
{
    public class CargoPassengerTaxi:Car,Icargo,Ipassengert
    {
        public float CargoMaxMass
        { get; set; }


        public float CargoMaxVolume
        { get; set; }


        public short CapacityPassengert
        { get; set; }

    }
}
