using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var timer = Stopwatch.StartNew();
            obj.GetOutputList();
            timer.Stop();
            Console.WriteLine("Выполнение метода заняло {0} мс", timer.ElapsedMilliseconds);
           // obj.ToConsole();
            obj.ToFile();
     

        }
    }
}
