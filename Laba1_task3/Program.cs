using System;

namespace Laba1_task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double doubleA = 1000;
            double doubleB = 0.0001;
            float floatA = 1000f;
            float floatB = 0.0001f;

            double res1;
            float res2;
            res1 = (Math.Pow((doubleA - doubleB),3) - Math.Pow(doubleA, 3)) / (3* doubleA * doubleB* doubleB - Math.Pow(doubleB, 3) - 3* doubleA * doubleA * doubleB);
            res2 = ((float)Math.Pow((floatA - floatB), 3) - (float)Math.Pow(floatA, 3)) / (3 * floatA * floatB * floatB - (float)Math.Pow(floatB, 3) - 3 * floatA * floatA * floatB);
            Console.WriteLine(res1);
            Console.WriteLine(res2);
        }
    }
}
