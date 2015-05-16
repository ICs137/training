using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiStation
{
    public interface Icar
    {
        string ModelName { get; }
        float Mass { get; }
        int Price { get; }
        int FuelConsumption { get; }
        int MaxSpeed { get; }
        DateTime CreationDate { get; }
    }
}
