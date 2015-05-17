using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiStation
{
    public abstract class Car : Icar
    {



         static CarBrands carBrand;

         public virtual CarBrands CarBrand { get { return carBrand; } }


        public int Price
        { get; set; }

        public Double FuelConsumption
        { get; set; }

        public int MaxSpeed
        { get; set; }

        public DateTime ManufacturedDate
        { get; set; }

        public Int16 CapacityPassengert
        { get; set; }

        public virtual void GetInfoCar()
        {
            Console.WriteLine("марка - {0,10}, максимальная скорость ={2,4},  расход ={3}", this.CarBrand,  this.MaxSpeed, this.FuelConsumption); ;
        }
    }
}
