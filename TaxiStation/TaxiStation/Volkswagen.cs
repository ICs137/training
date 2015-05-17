using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiStation
{
    public  class Volkswagen: Car,IVolkswagen
    {
        static  CarBrands carBrand = CarBrands.Volkswagen;
        public override CarBrands CarBrand
        {
            get
            {
                return carBrand;
            }
        }
        public VolkswagenList ModelName
           { get;  set; }

        public override void GetInfoCar() 
        { Console.WriteLine("марка - {0,10}, модель-{1, 8}, максимальная скорость ={2,4},  расход топлива ={3}", this.CarBrand, this.ModelName, this.MaxSpeed, this.FuelConsumption); }
      

    }
}
