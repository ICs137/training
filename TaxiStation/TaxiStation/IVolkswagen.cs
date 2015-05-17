using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiStation
{
    public interface IVolkswagen:Icar
    {

      
       VolkswagenList ModelName { get; }


    }
}
