using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    class Program
    {
        static void Main(string[] args)
        {

            StaticParam obj = new StaticParam(20);



            obj.statik[2,2] = 1;
            obj.statik[2,1] = 1;
            obj.statik[2, 3] = 1;
            obj.statik[1, 3] = 1;
            obj.statik[0,2] = 1;
   

 do
            {
                Console.Clear();
                obj.GetPoint();
                obj.SetPoint();
                obj.planner.Clear();
                System.Threading.Thread.Sleep(1000); 
            }

            while (Console.KeyAvailable == false);




/*
             Console.Clear();
             obj.GetPoint();
             obj.SetPoint();
             obj.planner.Clear();
             Console.Clear();
             obj.GetPoint();
             foreach (KeyValuePair<Double, int> o in obj.planner)
             {

                 int i = (Int32)Math.Round(o.Key, 0);

                 int j = (Int16)((o.Key - i + 0.001) * 100);

                 Console.Write(o.Key + "  " + i + "  ----   " + j + " =");
                 Console.WriteLine(o.Value);
                 Console.WriteLine();
             }



*/


        }
    }
}
