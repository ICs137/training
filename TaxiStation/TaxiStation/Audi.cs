using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiStation
{
    public class Audi:Car,IAudi
    {

    static CarBrands carbrand = CarBrands.Audi ;

    public AudiList NameLine
    { get; set; }
    }
}
