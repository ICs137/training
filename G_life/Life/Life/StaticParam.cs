using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    public class StaticParam
    {
        int[,] statik;


        public StaticParam (int n)
        {
       
            int i,j;
            statik = new int[n, n];
            for (i=0;i<n;i++)
            {
                for (j=0;j<n;j++)
                {
                    statik[i, j] = 0;
                }
            }
        }

        Dictionary<Double, int> planner = new Dictionary<Double, int>();


        public void SetPointPlanner(int i,int j)
        {
            if (!planner.ContainsKey(CoordinatesToKey(i, j)))
            { planner.Add(CoordinatesToKey(i, j), 0); }
            else { planner[CoordinatesToKey(i, j)]++; }
                    
        }

        public void CheckNeighbor(int i,int j)
        {
            if (i>0)
            {
               SetPointPlanner (i-1,j);
                if (j>0)
                {
                    SetPointPlanner(i - 1, j-1);
                    SetPointPlanner(i ,  j-1);
                }

                if (j<statik.GetLength(1))
                {
                    SetPointPlanner(i - 1, j + 1);
                    SetPointPlanner(i , j + 1);
                }

            }
            if (i<statik.GetLength(0))
            {

                SetPointPlanner(i +1, j);

                if (j > 0)
                {
                    SetPointPlanner(i + 1, j - 1);
                 
                }

                if (j < statik.GetLength(1))
                {
                    SetPointPlanner(i + 1, j + 1);
                   
                }

            }

        }




        public  void  GetPoint()
        {
            int i,j;

              for (i = 0; i < statik.GetLength(0); i++ )
            {
                for (j=0;j<statik.GetLength(1);j++)
                {
                   if( statik[i,j]!=0)
                   {
                    SetPointPlanner(i, j);
                    CheckNeighbor(i, j);
                   }
                }
            }
         
        }

        public static Double CoordinatesToKey(int i, int j)
        {
                  return i + j / 1000;
        }

        public static Double KeyToCoordinates(int i, int j)
        {
            return 212.23;
        }

    }
}
