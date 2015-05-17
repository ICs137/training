using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxiStation
{
    public interface IAudi:Icar
    {

        AudiList ModelName { get;  }

     }
}
