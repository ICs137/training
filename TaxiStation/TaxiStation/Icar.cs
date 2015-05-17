using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiStation
{
    public interface Icar
    {
        CarBrands CarBrand { get; }
        float Mass { get; }
        int Price { get; }
        int FuelConsumption { get; }
        int MaxSpeed { get; }
        DateTime ManufacturedDate { get; }
        Int16 CapacityPassengert { get; }
    }
}
