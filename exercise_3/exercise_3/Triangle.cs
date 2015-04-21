using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace exercise_3
{
    class Triangle
    {
        int a;
        int b;
        int c;
        bool validT = false;
        
        
        
        
        
        
        
        
        
        
        public int A
        {
            get { return a; }
            set
            {

                if (ValidT(value,B,C))
                {
                    a = value; 
                }
                else
                    Warning2();

            }
        }








        public int B
        {
            get { return b; }
            set
            {
                if (ValidT(A,value, C))
                {
                    b = value; 
                }
                else
                    Warning2();

            }
        }

        public int C
        {
            get { return c; }
            set
            {

                if (ValidT(A,B,value))
                {
                    c = value; 
                }
                else
                    Warning2();

            }
        }

        public static void Warning()

                {Console.WriteLine("Нарушено правило создания треугольника");  }

        public static void Warning2()

                { Warning(); Console.WriteLine(" новое значение не установлено "); }



        public Triangle(int a,int b,int c  )

        {
          this.a = a; this.b = b; this.c = c;
          if (!ValidT(a,b,c))
              Warning();
        }

        public void checT()
        {

            if (ValidT(A,B,C))
            {
                if (A * A + B * B > C *C & A *A + C * C >B * B & C * C + B * B > A * A)
                    Console.WriteLine("Треугольник остроугольный");
                else
                    if (A * A + B * B == C * C | A* A + C *C == B * B | C * C + B * B == A * A)
                        Console.WriteLine("Треугольник  прямоугольный");
                    else
                        Console.WriteLine("Треугольник тупоугольный");
            }

        }

        public bool ValidT(int A,int B, int C)

        {
            int min1=A;
            int min2=B;
            int max =C;
            if ( A>C)
            { max = A; min1 = C; }
            if (B>max)
            { max = B; min2 = C; }
            if (A * B * C != 0)
                if (min2 + min1 > max)
                    validT = true;
                else validT =false;

                    return validT;
        }
    }
}
