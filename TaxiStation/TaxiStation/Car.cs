using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiStation
{
    public abstract class Car : Icar
    {
        public string ModelName
        { get;set; }


        public float Mass
        { get; set; }

        public int Price
        { get; set; }

        public int FuelConsumption
        { get; set; }

        public int MaxSpeed
        { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
