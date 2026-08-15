using System;

namespace Laba3
{
    class Program
    {
        static double SumN(double x, int n) 
        {
            double a = Math.Pow(x, 2), res = 0;
            for (int i = 1; i <= n; i++)
            {
                double b = 2 * i * (2 * i - 1);
                res += a / b;
                a *= -a;
            }
            return res;
        }
        
        static double SumE(double x, double e)
        {
            double prevSum;
            double a = Math.Pow(x, 2),  sum = 0;
            int i = 1;
            do
            {
                double b = 2 * i * (2 * i - 1);
                prevSum = sum;
                sum += a / b;
                a *= -a;
                i++;
            }
            while (Math.Abs(sum - prevSum) >= e); 
            return sum;
        }

        static void Main()
        {
            double a = 0.1, b = 0.8, e = 0.0001;
            int k = 10, n = 10;
            double step = (double)((b - a) / k);

            for (double x = a; x <= b; x += step)
            {
                double y = x * Math.Atan(x) - Math.Log(Math.Pow(1 + x * x, 0.5));

                double SN = SumN(x, n);

                double SE = SumE(x, e);

                Console.WriteLine($"X = {x}  SN =  {SN:F4} SE =  {SE:F4}   Y = {y:F4}");
            }
        }
    }
}