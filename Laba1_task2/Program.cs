using System;

namespace Laba1_task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x, y;
            Console.WriteLine("Введите координаты точки: ");
            string buf;
            buf = Console.ReadLine();
            bool ok = double.TryParse(buf, out x);
            while (!ok)
            {
                Console.WriteLine("ошибка, повторите ввод");
                buf = Console.ReadLine();
                ok = Double.TryParse(buf, out x);
            }
            buf = Console.ReadLine();
            ok = double.TryParse(buf, out y);
            while (!ok)
            {
                Console.WriteLine("ошибка, повторите ввод");
                buf = Console.ReadLine();
                ok = Double.TryParse(buf, out y);
            }

            bool inArea = (x * x + y * y <= 1);
            if (inArea)
            {
                Console.WriteLine("Точка входит в заданную область");

            }
            else
            {
                Console.WriteLine("Точка не входит в заданную область");
            }
        }
    }
}

