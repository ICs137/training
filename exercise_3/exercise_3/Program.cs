using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_3
{
       class Program
    {
        static void Main(string[] args)
        {



            Console.Write("Введите сторону [а] ");

            int a = int.Parse(Console.ReadLine());

            Console.Write("Введите сторону [b] ");
            int b = int.Parse(Console.ReadLine());

            Console.Write("Введите сторону [c] ");
            int c = int.Parse(Console.ReadLine());


            Triangle T = new Triangle(a,b,c);
            T.checT();

            Console.Write("Введите сторону [c] ");
            T.C = int.Parse(Console.ReadLine());
            T.checT();

        }
    }
}
// Не совсем понимаю где в данной задаче применить перечислитель в силу отстутствия коллекций.