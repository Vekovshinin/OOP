using System;

namespace Laba9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Triangle tr = null;
            TriangleArray trArray = null;   

            while (true)
            {
                UserInterface userInterface = new UserInterface();
                userInterface.Menu();

                int choice = UserInterface.GetMenuChoice();
                switch (choice)
                {
                    case 1:
                        tr = userInterface.GetTriangleFromUser();
                        userInterface.Pause();
                        userInterface.PrintTriangle(tr);
                        break;
                    case 2:
                        if (tr != null)
                        {
                            userInterface.Pause();
                            userInterface.PrintTriangle(tr);
                            double square = tr.CalculateSquare();
                            userInterface.PrintSquare(square);
                        }
                        else 
                        {
                            Console.WriteLine("Для начала создайте объект");
                            Console.ReadLine();
                            userInterface.Pause();
                        }
                        break;
                    case 3:
                        userInterface.Pause();
                        userInterface.PrintCount(Triangle.Count);
                        break;
                    case 4:
                        userInterface.Pause();
                        Console.WriteLine("Унарные операции: ");

                        Console.WriteLine("Введите стороны треугольника: ");
                        Triangle unarTr1 = userInterface.GetTriangleFromUser();
                        userInterface.PrintTriangle(unarTr1);
                        ++unarTr1;
                        Console.WriteLine("Увеличение сторон треугольника на 1");
                        userInterface.PrintTriangle(unarTr1);

                        Console.WriteLine("Введите стороны треугольника: ");
                        Triangle unarTr2 = userInterface.GetTriangleFromUser();
                        userInterface.PrintTriangle(unarTr2);
                        --unarTr2;
                        Console.WriteLine("Уменьшение сторон треугольника на 1");
                        userInterface.PrintTriangle(unarTr2);

                        Console.ReadLine();
                        userInterface.Pause();

                        break;
                    case 5:
                        userInterface.Pause();
                        Console.WriteLine("Операции приведения типа: ");

                        Console.WriteLine("Введите стороны треугольника: ");
                        Triangle conversionTr = userInterface.GetTriangleFromUser();
                        userInterface.PrintTriangle(conversionTr);

                        Console.WriteLine($"(double)conversionTr = {(double)conversionTr}");

                        Console.WriteLine($"(bool)conversionTr = {(bool)conversionTr}");

                        Console.ReadLine();
                        userInterface.Pause();

                        break;
                    case 6:
                        userInterface.Pause();
                        Console.WriteLine("Бинарные операции: ");

                        Console.WriteLine("Введите стороны первого треугольника: ");
                        Triangle binaryTr1 = userInterface.GetTriangleFromUser();
                        double squere1 = binaryTr1.CalculateSquare();

                        Console.WriteLine("Введите стороны второго треугольника: ");
                        Triangle binaryTr2 = userInterface.GetTriangleFromUser();
                        double squere2 = binaryTr2.CalculateSquare();

                        userInterface.Pause();
                        Console.WriteLine("Бинарные операции: ");
                        userInterface.PrintTriangle(binaryTr1);
                        userInterface.PrintSquare(squere1);
                        userInterface.PrintTriangle(binaryTr2);
                        userInterface.PrintSquare(squere2);

                        Console.WriteLine($"binaryTr1 <= binaryTr2: {binaryTr1 <= binaryTr2}");
                        Console.WriteLine($"binaryTr1 >= binaryTr2: {binaryTr1 >= binaryTr2}");

                        Console.ReadLine();
                        userInterface.Pause();

                        break;
                    case 7:
                        userInterface.Pause();
                        Console.WriteLine("Заполнение массива треугольников вручную: ");

                        int size = userInterface.GetArraySizeFromUser();
                        trArray = new TriangleArray(size, userInterface);

                        userInterface.Pause();
                        trArray.PrintArray();

                        break;
                    case 8:
                        userInterface.Pause();
                        Console.WriteLine("Заполнение массива треугольников случайно: ");

                        size = userInterface.GetArraySizeFromUser();
                        trArray = new TriangleArray(size);

                        userInterface.Pause();
                        trArray.PrintArray();

                        break;
                    case 9:
                        if (trArray != null)
                        {
                            userInterface.Pause();
                            trArray.PrintArray();
                        }
                        else
                        {
                            Console.WriteLine("Массива не существует");
                        }
                        break;
                    case 10:
                        int indexToAccess = userInterface.GetIndexToAccess();
                        try
                        {
                            userInterface.Pause();
                            trArray.PrintArray();
                            Triangle accessedTr = trArray[indexToAccess - 1];
                            Console.WriteLine($"Элемент под номером {indexToAccess}");
                            userInterface.PrintTriangle(accessedTr);
                            trArray[0] = new Triangle(1, 3, 2);
                            trArray[100] = new Triangle(1, 3, 4);
                            trArray.PrintArray();
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            userInterface.InterfaceError(e.Message);
                        }
                        break;
                    case 11:
                        if (trArray != null)
                        {
                            userInterface.Pause();
                            int minSquareIndex = userInterface.PrintArrayIndexWithMinSquare(trArray);
                            Console.WriteLine($"Номер элемента с минимальной площадью: {minSquareIndex}");
                        }
                        else
                        {
                            userInterface.Pause();
                            Console.WriteLine("Массива не существует");
                        }
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        userInterface.Pause();
                        userInterface.InterfaceError("Неверный выбор, пожалуйста выберите снова.");
                        break;
                }

            }
        }
    }
}

