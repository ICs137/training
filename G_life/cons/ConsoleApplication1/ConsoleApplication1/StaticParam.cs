using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class StaticParam
    {

        public int[,] statik;


        public StaticParam(int n)
        {

            int i, j;
            statik = new int[n, n];
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    statik[i, j] = 0;
                }
            }
        }

     public   Dictionary<Double, int> planner = new Dictionary<Double, int>();


        public void SetPointPlanner(int i, int j)
        {
            if (!planner.ContainsKey(CoordinatesToKey(i, j)))
            { planner.Add(CoordinatesToKey(i, j), 1); }
            else { planner[CoordinatesToKey(i, j)]+=1; }

        }


        public void SetPointPlanner2(int i, int j)
        {
            if (!planner.ContainsKey(CoordinatesToKey(i, j)))
            { planner.Add(CoordinatesToKey(i, j), 0); }
        }





        public void CheckNeighbor(int i, int j)
        {

            
            SetPointPlanner(i - 1, j - 1);
            SetPointPlanner(i - 1, j);
            SetPointPlanner(i - 1, j + 1);
            SetPointPlanner(i, j + 1);
            SetPointPlanner(i + 1, j + 1);
            SetPointPlanner(i + 1, j);
            SetPointPlanner(i + 1, j - 1);
            SetPointPlanner(i, j - 1);
           
           
            /* if (i > 0)
             {
                 SetPointPlanner(i - 1, j);

                 if (j > 0)
                 {
                     SetPointPlanner(i - 1, j - 1);
                     SetPointPlanner(i, j - 1);
                 }

                 if (j < statik.GetLength(1))
                 {
                     SetPointPlanner(i - 1, j + 1);
                     SetPointPlanner(i, j + 1);
                 }
             }
                      if (i < statik.GetLength(0))
             {
                 SetPointPlanner(i + 1, j);
                                 if (j > 0)
                 {
                     SetPointPlanner(i + 1, j - 1);
                 }

                 if (j < statik.GetLength(1))
                 {
                     SetPointPlanner(i + 1, j + 1);
                 }

            } */

        }




        public void GetPoint()
        {
            int i, j;

            for (i = 0; i < statik.GetLength(0); i++)
            {
                for (j = 0; j < statik.GetLength(1); j++)
                {
                    Console.Write(statik[i, j] + " ");
                    if (statik[i, j] != 0)
                    {
                       
                        SetPointPlanner2(i, j);
                        CheckNeighbor(i, j);
                    }
                }
                Console.WriteLine();
            }

        }

        public static Double CoordinatesToKey(int i, int j)
        {
            Double h= (Double)i + (Double)j/100;
            return h;
        }

     
public void SetPoint()
        {
            foreach (KeyValuePair<Double, int> o in planner)
            {

               
               
                int i = (Int16)Math.Round(o.Key, 0);
                int j = (Int16)((o.Key-i+0.001)*100);

                if (i >= 0 && j >= 0 && i < statik.GetLength(0) && j < statik.GetLength(1))
                {
                    if (o.Value < 2 || o.Value > 3)
                    { statik[i, j] = 0; }
                    else
                    {
                        if (o.Value == 3)
                        { statik[i, j] = 1; }
                    }
                }
            }

        }



    }
}
