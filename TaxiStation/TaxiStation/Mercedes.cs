using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiStation
{
    public class Mercedes: Car,IMercedes
    {

    static CarBrands carbrand = CarBrands.Mercedes;

    public MercedesList NameLine
    { get; set; }
    }
}
