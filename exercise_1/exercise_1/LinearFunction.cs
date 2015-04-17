using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1
{
    class LinearFunction
    {

        float a;
        public float A
        {
            get { return a; }
            set { a = value; }
        }

        float b;
        public float B
        {
            get { return b; }
            set { b = value; }
        }

        public LinearFunction(float A, float B)
        {
        this.A = A;
        this.B = B;
        }

        public float Functin(float X)
        {
            return A * X + B;
        }    


    }
}
