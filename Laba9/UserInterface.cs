using System;

namespace Laba9
{
    public class UserInterface
    {
        public static double InputDouble()
        {
            double input;
            bool ok = Double.TryParse(Console.ReadLine(), out input);
            while (!ok)
            {
                Console.WriteLine("Неверный ввод, попробуйте снова:");
                ok = Double.TryParse(Console.ReadLine(), out input);
            }
            return input;
        }

        public static int InputInt()
        {
            int input;
            bool ok = Int32.TryParse(Console.ReadLine(), out input);
            while (!ok)
            {
                Console.WriteLine("Неверный ввод, попробуйте снова:");
                ok = Int32.TryParse(Console.ReadLine(), out input);
            }
            return input;
        }

        public void Menu()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Ввод сторон треугольника");
            Console.WriteLine("2. Вычисление площади треугольника");
            Console.WriteLine("3. Количество созданных объектов");
            Console.WriteLine("4. Унарные операции");
            Console.WriteLine("5. Операции приведения типа");
            Console.WriteLine("6. Бинарные операции");
            Console.WriteLine("7. Создать массив сторон треугольника вручную");
            Console.WriteLine("8. Создать массив сторон треугольника случайно");
            Console.WriteLine("9. Вывести массив сторон треугольника");
            Console.WriteLine("10. Доступ к элементу массива");
            Console.WriteLine("11. Найти номер элемента с минимальной площадью");
            Console.WriteLine("0. Выход");
        }

        public void Pause()
        {
            Console.Clear();
            Console.Clear();
        }

        public static int GetMenuChoice()
        {
            int choice = InputInt();
            return choice;
        }

        public Triangle GetTriangleFromUser()
        {
            Console.WriteLine("Введите длину стороны а: ");
            double a = InputDouble();

            Console.WriteLine("Введите длину стороны b: ");
            double b = InputDouble();

            Console.WriteLine("Введите длину стороны c: ");
            double c = InputDouble();

            return new Triangle(a, b, c);
        }

        public void PrintTriangle(Triangle tr)
        {
            Console.WriteLine($"Стороны: А = {tr.A}, B = {tr.B}, C = {tr.C}");
        }

        public void PrintSquare(double square)
        {
            Console.WriteLine($"Площадь треугольника: {square}");
        }

        public void PrintCount(int count)
        {
            Console.WriteLine($"Количество объектов: {count}");
        }

        public void InterfaceError(string message)
        {
            Console.WriteLine($"Ошибка: {message}");
        }

        public void PrintArray(Triangle[] arr)
        {
            Console.WriteLine("Массив сторон: ");
            foreach (var  tr in arr)
            {
                PrintTriangle(tr);
            }
        }

        public int GetArraySizeFromUser()
        {
            Console.WriteLine("Введите размер массива: ");
            return InputInt();
        }

        public int GetIndexToAccess()
        {
            Console.WriteLine("Введите номер элемента для доступа: ");
            return InputInt();
        }

        public int PrintArrayIndexWithMinSquare(TriangleArray arr)
        {
            Console.WriteLine("Номер элемента с наименьшей площадью: ");
            return arr.FindIndexWithMinSquare();
        }
    }
}
