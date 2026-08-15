using System;

namespace Laba9
{
    public class TriangleArray
    {
        private Triangle[] arr;

        public TriangleArray()
        {
            arr = new Triangle[0];
        }

        public TriangleArray(int size)
        {
            arr = new Triangle[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i] = new Triangle(random.NextDouble() * 10, random.NextDouble() * 10, random.NextDouble() * 10);
            }
        }

        public TriangleArray(int size, UserInterface userInterface)
        {
            arr = new Triangle[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Введите длины сторон треугольника {i + 1}: ");
                arr[i] = userInterface.GetTriangleFromUser();
            }
        }

        public void PrintArray()
        {
            foreach (var tr in arr)
            {
                UserInterface userInterface = new UserInterface();
                userInterface.PrintTriangle(tr);
            }
        }

        // индексатор для доступа к элементам массива с проверкой выхода индекса за пределы массива
        public Triangle this[int index]
        {
            get
            {
                if (index < 0 || index >= arr.Length)
                  throw new IndexOutOfRangeException("Индекс выходит за пределы массива.");

                return arr[index];
            }
            set
            {
                if (!(index < 0 || index >= arr.Length))
                    arr[index] = value;
            }
        }

        public int FindIndexWithMinSquare()
        {
            if (arr.Length == 0)
                throw new InvalidOperationException("Массив треугольников пуст.");

            PrintSquare();

            int minIndex = 0;
            double minSquare = double.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                double square = arr[i].CalculateSquare();
                if ((square < minSquare) && (square >= 0))
                {
                    minSquare = square;
                    minIndex = i;
                }
            }

            return minIndex + 1;
        }

        public void PrintSquare()
        {
            Console.WriteLine("Площади треугольников:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Треугольник {i + 1}: {arr[i].CalculateSquare()}");
            }
        }
    }
}
