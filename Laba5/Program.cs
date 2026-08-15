using System;
using System.Linq;
using System.Threading;

namespace LaboratoryWork_5
{
    internal class Program
    {
        static int InputInt(string buf = "")
        {
            int input;
            if (buf != "")
                Console.WriteLine(buf);
            bool ok = Int32.TryParse(Console.ReadLine(), out input);
            while (!ok)
            {
                Console.WriteLine("Ошибка ввода, попробуйте снова:");
                ok = Int32.TryParse(Console.ReadLine(), out input);
            }
            return input;
        }

        static void CheckNumber(int low, int upp, ref int value, string msg = "Неверное значение, попробуйте снова: ")
        {
            if (low > upp)
                (low, upp) = (upp, low);
            while (value < low || value > upp)
            {
                Console.WriteLine(msg);
                value = InputInt();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\t\tМеню");
            Console.WriteLine("1. Работа с одномерным массивом");
            Console.WriteLine("2. Работа с двумерным массивом");
            Console.WriteLine("3. Работа с рваным массивом");
            Console.WriteLine("0. Выход");
        }

        static void Pause()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadLine();
        }

        // одномерный массив
        static void CreateArray(int[] array)
        {
            int choice = InputInt("Выберете способ заполнения:\n1.Случайными числами\n2. Вручную");
            CheckNumber(1, 2, ref choice);
            if (choice == 1)
            {
                Random rand = new Random();
                for (int i = 0; i < array.Length; ++i)
                    array[i] = rand.Next(-50, 50);
            }
            if (choice == 2)
            {
                for (int i = 0; i < array.Length; ++i)
                {
                    array[i] = InputInt("Введите элемент массива (от -50 до 50): ");
                    CheckNumber(-50, 50, ref array[i]);
                }
            }
        }

        static void PrintArray(int[] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Массив пустой");
                return;
            }
            Console.WriteLine("Одномерный массив:");
            Console.Write("{");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(", "); 
                }
            }
            Console.WriteLine("}");
        }

        static void DeleteAverage(ref int[] array)
        {
            double aver = array.Average();
            int average = (int) aver;
            Console.WriteLine($"Среднее арифметическое массива: {average}");
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == average)
                {
                    count++;
                }
            }
            int[] newArray = new int[array.Length - count];
            for (int i = 0; i < newArray.Length; i++)
            {
                if (array[i] != average)
                {
                    newArray[i] = array[i];
                }
            }
            array = newArray;
            PrintArray(array);
        }

        // двумерный массив
        static void CreateArray(int[,] array)
        {
            int choice = InputInt("Выберете способ заполнения:\n1. Случайными числами\n2. Вручную");
            CheckNumber(1, 2, ref choice);
            if (choice == 1)
            {
                Random rand = new Random();
                for (int i = 0; i < array.GetLength(0); ++i)
                {
                    for (int j = 0; j < array.GetLength(1); ++j)
                        array[i, j] = rand.Next(-50, 50);
                }
            }
            if (choice == 2)
            {
                for (int i = 0; i < array.GetLength(0); ++i)
                {
                    for (int j = 0; j < array.GetLength(1); ++j)
                    {
                        array[i, j] = InputInt("Введите элемент массива (от -50 до 50): ");
                        CheckNumber(-50, 50, ref array[i, j]);
                    }
                }
            }
        }

        static void PrintArray(int[,] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Массив пустой");
                return;
            }
            Console.WriteLine("Двумерный массив:");
            string row = "";
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                    row = row + array[i, j] + '\t';
                Console.WriteLine(row);
                row = "";
            }
        }

        static void AddColumn(ref int[,] array)
        {
            int[,] newArray = new int[array.GetLength(0), array.GetLength(1) + 1];
            int choice = InputInt("Выберете способ заполнения:\n1. Случайными числами\n2. Вручную");
            CheckNumber(1, 2, ref choice);
            if (choice == 1)
            {
                Random rand = new Random();
                for (int i = 0; i < newArray.GetLength(0); ++i)
                {
                    for (int j = 0; j < newArray.GetLength(1); ++j)
                    {
                        if (j != newArray.GetLength(1) - 1)
                            newArray[i, j] = array[i, j];
                        else
                            newArray[i, j] = rand.Next(-50, 50);
                    }
                }
            }
            if (choice == 2)
            {
                for (int i = 0; i < newArray.GetLength(0); ++i)
                {
                    for (int j = 0; j < newArray.GetLength(1); ++j)
                    {
                        if (j != newArray.GetLength(1) - 1)
                            newArray[i, j] = array[i, j];
                        else
                            newArray[i, j] = InputInt("Введите новый элемент массива: ");
                    }
                }
            }
            array = newArray;
            PrintArray(array);
        }

        // рваный массив
        static void CreateArray(ref int[][] array)
        {
            int rows = InputInt("Введите количество строк:");
            CheckNumber(1, 20, ref rows);
            array = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                int columns = InputInt($"Введите количество элементов строки {i + 1}");
                CheckNumber(1, 20, ref columns);
                array[i] = new int[columns];
                CreateArray(array[i]);
            }
        }

        static void PrintArray(int[][] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Массив пустой");
                return;
            }
            Console.WriteLine("Рваный массив:");
            string row = "";
            for (int i = 0; i < array.Length; ++i)
            {
                for (int j = 0; j < array[i].Length; ++j)
                    row = row + array[i][j] + '\t';
                Console.WriteLine(row);
                row = "";
            }
        }

        static void DeleteElement(int k, ref int[][] array)
        {
            int rowCount = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                bool countK = false;    
                for (int j = 0; j < array[i].Length; ++j)
                {
                    if (array[i][j] == k)
                    {
                        countK = true;  
                        break;
                    }
                }
                if (!countK)
                    rowCount++;
            }

            int[][] newArray = new int[rowCount][];
            int resIndex = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                bool countK = false;
                for (int j = 0; j < array[i].Length; ++j)
                {
                    if (array[i][j] == k)
                    {
                        countK = true;
                        break;
                    }
                }
                if (!countK)
                {
                    newArray[resIndex] = array[i];
                    resIndex++;
                }
            }
            array = newArray;
            PrintArray(array); 
        }

        // меню
        static void Menu()
        {
            int choice;
            int[] Array = { };
            int[,] matr = { { }, { } };
            int[][] raggedArray = { };
            do
            {
                Console.Clear();
                ShowMenu();
                choice = InputInt();
                switch (choice)
                {
                    case 0:
                        break;
                    case 1:
                        Console.Clear();
                        MenuArray(ref Array);
                        break;
                    case 2:
                        Console.Clear();
                        MenuMatr(ref matr);
                        break;
                    case 3:
                        Console.Clear();
                        MenuRaggedArray(ref raggedArray);
                        break;
                    default:
                        Console.WriteLine("Неправильно введено значение");
                        Pause();
                        break;
                }
            } while (choice != 0);
        }

        static void MenuArray(ref int[] array)
        {
            int operation;
            do
            {
                Console.Clear();
                operation = InputInt("1. Создать массив\n2. Вывести массив\n3. Удалить элемент равный среднему арифметическому элементов массива\n0. Назад");
                CheckNumber(0, 3, ref operation);
                if (operation == 0)
                {
                    Console.WriteLine("Выход в меню");
                }
                if (operation == 1)
                {
                    int lengthArray = InputInt("Введите длину массива: ");
                    CheckNumber(1, 50, ref lengthArray);
                    array = new int[lengthArray];
                    CreateArray(array);
                    Console.WriteLine("Массив создан");
                    PrintArray(array);
                }
                if (operation == 2)
                {
                    PrintArray(array);
                }
                if (operation == 3)
                {

                    if (array.Length > 0)
                    {
                        DeleteAverage(ref array);
                        Console.WriteLine("Элементы, равные среднему арифметическому массива удалены");
                    }
                    else Console.WriteLine("Массив пустой, сначала заполните его");
                }
                Pause();
            } while (operation != 0);
        }

        static void MenuMatr(ref int[,] matr)
        {
            int operation;
            do
            {
                Console.Clear();
                operation = InputInt("1. Создать массив\n2. Вывести массив\n3. Добавить столбец в конец матрицы\n0. Назад");
                CheckNumber(0, 3, ref operation);
                if (operation == 0)
                {
                    Console.WriteLine("Выход в меню");
                }
                if (operation == 1)
                {
                    int rows = InputInt("Введите количество строк: ");
                    CheckNumber(1, 20, ref rows);
                    int columns = InputInt("Введите количество столбцов: ");
                    CheckNumber(1, 20, ref columns);
                    matr = new int[rows, columns];
                    CreateArray(matr);
                    Console.WriteLine("Массив создан");
                    PrintArray(matr);
                }
                if (operation == 2)
                {
                    PrintArray(matr);
                }
                if (operation == 3)
                {
                    if (matr.Length > 0)
                    {
                        AddColumn(ref matr);
                        Console.WriteLine("Столбец добавлен");
                    }
                    else Console.WriteLine("Массив пустой, сначала заполните его");
                }
                Pause();
            } while (operation != 0);
        }

        static void MenuRaggedArray(ref int[][] raggedArray)
        {
            int operation;
            do
            {
                Console.Clear();
                operation = InputInt("1. Создать массив\n2. Вывести массив\n3. Удалить все строки, в которых встречается заданное число K\n0. Назад");
                CheckNumber(0, 3, ref operation);
                if (operation == 0)
                {
                    Console.WriteLine("Выход в меню");
                }
                if (operation == 1)
                {
                    CreateArray(ref raggedArray);
                    Console.WriteLine("Массив создан");
                    PrintArray(raggedArray);
                }
                if (operation == 2)
                {
                    PrintArray(raggedArray);
                }
                if (operation == 3)
                {
                    
                    if (raggedArray.Length > 0)
                    {
                        int k = InputInt("Введите элемент, который надо удалить");
                        CheckNumber(-50, 50, ref k);
                        DeleteElement(k, ref raggedArray);
                        Console.WriteLine($"Строки, содержащие {k} удалены");
                    }
                    else Console.WriteLine("Массив пустой, сначала заполните его");
                }
                Pause();
            } while (operation != 0);
        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}
