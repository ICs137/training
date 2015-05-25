using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
    class Program
    {
        static void Main(string[] args)
        {

            Concordance obj = new Concordance();

            obj.ReadText();
            obj.CreateConcordance();
            obj.GetOutputList();
            obj.ToConsole();
            obj.ToFile();


        }
    }
}
