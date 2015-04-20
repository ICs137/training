using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_2
{
       class Program
    {
        static void Main(string[] args)
        {
           

             ArrayList list = new ArrayList();
             Random rnd= new Random();

             for (Int32 i = 0; 10000 > i; i++) 
                 {
                 
                      list.Add(  new Item ("name"+i, rnd.Next(1,1000),rnd.Next(1,500)));
                 
                 }

             Int64 sum=0;
             foreach (Item  i in list)
                {
                    
                sum+=(i.in_total());
                 
                }

             Console.WriteLine("Общая сумма всех стоимостей товаров ="+sum);

        }
    }
}
