using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiStation
{
    public abstract class Car : Icar
    {



         static CarBrands carBrand;

         public CarBrands CarBrand { get { return carBrand; } }

        public float Mass
        { get; set; }

        public int Price
        { get; set; }

        public int FuelConsumption
        { get; set; }

        public int MaxSpeed
        { get; set; }

        public DateTime ManufacturedDate
        { get; set; }

        public Int16 CapacityPassengert
        { get; set; }
    }
}
