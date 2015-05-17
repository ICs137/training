using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiStation
{
    public class Audi:Car,IAudi
    {

    static CarBrands carBrand = CarBrands.Audi ;

    public override CarBrands CarBrand
    {
        get
        {
            return carBrand;
        }
    }

    public override void GetInfoCar()
    { Console.WriteLine("марка - {0,10}, модель-{1,6}, макс. скорость ={2,4},  расход = {3,4}", this.CarBrand, this.ModelName, this.MaxSpeed, this.FuelConsumption); }

    public AudiList ModelName
    { get;  set; }
    }
}
