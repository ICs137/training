using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1
{

    class Program
    {


        static void Main(string[] args)

        {


            float A,B,X;
          Console.Write("Введите переменную [a] : ");
          A = float.Parse(Console.ReadLine());

          Console.Write("Введите переменную [b] : ");
          B = float.Parse(Console.ReadLine());

          LinearFunction obj = new LinearFunction(A, B);

          Console.Write("Введите переменную [x] : ");
         X = float.Parse(Console.ReadLine());
         Console.WriteLine("Значение функции   y= " + Math.Round(obj.A, 3) + "*" + Math.Round(X, 3) + "+" + Math.Round(obj.B,3) + " = " + Math.Round(obj.Functin(X), 3));

         Console.ReadKey();
        }
    }
}
