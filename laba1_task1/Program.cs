using System;

namespace Laba1_task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            double x;
            int res1;
            bool res2, res3;
            double res4;

            Console.WriteLine("Введите n: ");
            string buf;
            buf = Console.ReadLine();
            bool ok = int.TryParse(buf, out n);
            while (!ok)
            {
                Console.WriteLine("Ошибка, повторите ввод");
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out n);
            }
            Console.WriteLine("Введите m: ");

            buf = Console.ReadLine();
            ok = int.TryParse(buf, out m);
            while (!ok)
            {
                Console.WriteLine("Ошибка, повторите ввод");
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out m);
            }

            res1 = n++ * m;
            Console.WriteLine($"n = {n}, m = {m}, n++ * m = {res1}");
            res2 = n++ < m;
            Console.WriteLine($"n = {n}, m = {m}, n++ < m = {res2}");
            res3 = --m > n;
            Console.WriteLine($"n = {n}, m = {m}, --m > n = {res3}");

            Console.WriteLine("Введите х: ");
            buf = Console.ReadLine();
            ok = Double.TryParse(buf, out x);
            while (!ok)
            {
                Console.WriteLine("Ошибка, повторите ввод");
                buf = Console.ReadLine();
                ok = Double.TryParse(buf, out x);
            }

            res4 = Math.Pow(x - Math.Pow(x, 2) + Math.Pow(x, 5), 1.0 / 3.0);
            if ((x - Math.Pow(x, 2) + Math.Pow(x, 5)) < 0)
            {
                res4 = -Math.Pow(-1 * (x - Math.Pow(x, 2) + Math.Pow(x, 5)), 1.0 / 3.0);
            }

            Console.WriteLine("Ответ: ");
            Console.WriteLine(res4);

        }
    }
}
