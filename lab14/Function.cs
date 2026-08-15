using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganizationLib;

namespace Laba11
{
    public class Function
    {
        public static void Pause()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(intercept: true);
        }

        public static double InputDouble(string stringForUser = "")
        {
            double input;
            if (stringForUser != "")
                Console.WriteLine(stringForUser);
            bool isDouble = Double.TryParse(Console.ReadLine(), out input);
            while (!isDouble)
            {
                Console.WriteLine("Ошибка ввода! Попробуйте снова:");
                isDouble = Double.TryParse(Console.ReadLine(), out input);
            }
            return input;
        }

        static public int InputInteger(string stringForUser = "")
        {
            int input;
            if (stringForUser != "")
                Console.WriteLine(stringForUser);
            bool isInteger = Int32.TryParse(Console.ReadLine(), out input);
            while (!isInteger)
            {
                Console.WriteLine("Ошибка ввода! Попробуйте снова:");
                isInteger = Int32.TryParse(Console.ReadLine(), out input);
            }
            return input;
        }
        static public void CheckNumber(int low, int upp, ref int value, string msg = "Неверное значение! Попробуйте снова: ")
        {
            if (low > upp)
                (low, upp) = (upp, low);
            while (value < low || value > upp)
            {
                Console.WriteLine(msg);
                value = InputInteger();
            }
        }
        static public void CheckNumber(double low, double upp, ref double value, string msg = "Неверное значение! Попробуйте снова: ")
        {
            if (low > upp)
                (low, upp) = (upp, low);
            while (value < low || value > upp)
            {
                Console.WriteLine(msg);
                value = InputDouble();
            }
        }
    }
}
