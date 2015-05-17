using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiStation
{
    public  class Volkswagen: Car,IVolkswagen
    {
        static CarBrands carbrand = CarBrands.Volkswagen;

        public VolkswagenList NameLine
           { get; set; }
        
    }
}
