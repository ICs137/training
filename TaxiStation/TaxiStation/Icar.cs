using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiStation
{
    public interface Icar
    {
        CarBrands CarBrand { get; }
        int Price { get; }
        Double FuelConsumption { get; }
        int MaxSpeed { get; }
        DateTime ManufacturedDate { get; }
        Int16 CapacityPassengert { get; }
        void GetInfoCar();

    }
}
