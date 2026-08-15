using lab12;
using Laba11;
using OrganizationLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace lab14
{
    internal class Program
    {
        static void Menu()
        {
            GenericCollection collection = new GenericCollection(3, 3);
            int choice;
            IEnumerable<Organization> result = null;
            Stopwatch stopWatch = new Stopwatch();
            Tree<Organization> orgTree = new Tree<Organization>();
            for (int i = 0; i < 7; i++)
            {
                Organization org = new Organization();
                org.RandInit();
                orgTree.Add(org);
            }
            do
            {
                Console.Clear();
                Console.WriteLine("Меню:\n"
                    + "0. Выход\n"
                    + "1. Where-запрос\n"
                    + "2. Count-запрос\n"
                    + "3. Union-запрос\n"
                    + "4. Average-запрос\n"
                    + "5. Group-запрос\n"
                    + "6. Выборка данных для дерева\n"
                    + "7. Агрегирование данных для дерева\n"
                    + "8. Сортировка дерева (по другому ключу)");
                choice = Function.InputInteger("Введите число: ");
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Завершение работы программы");
                        break;
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("Коллекция: ");
                            Print(collection.sortedDictionary);
                            int employeeCount = Function.InputInteger("Выведутся все организации с количеством сотрудников больше заданной." +
                                " \n Введите количество сотрудников: ");

                            result = Query.WhereLINQ(collection.sortedDictionary, employeeCount);
                            foreach (var elem in result)
                            {
                                Console.WriteLine(elem.ToString() + "\n");
                            }

                            result = collection.sortedDictionary.WhereExtension(el => el.EmployeeCount > employeeCount);
                            foreach (var elem in result)
                            {
                                Console.WriteLine(elem.ToString() + "\n");
                            }

                            long linqTotal = 0;
                            for (int i = 0; i < 5; i++)
                            {
                                Stopwatch stopwatch = Stopwatch.StartNew();
                                var linqResult = Query.WhereLINQ(collection.sortedDictionary, employeeCount).ToList();
                                stopwatch.Stop();
                                linqTotal += stopwatch.ElapsedTicks;
                            }

                            long extensionTotal = 0;
                            for (int i = 0; i < 5; i++)
                            {
                                Stopwatch stopwatch = Stopwatch.StartNew();
                                var extensionResult = collection.sortedDictionary.WhereExtension(org => org.EmployeeCount > employeeCount).ToList();
                                stopwatch.Stop();
                                extensionTotal += stopwatch.ElapsedTicks;
                            }

                            long total = 0;
                            List<Organization> res = new List<Organization>();
                            for (int i = 0; i < 5; i++)
                            {
                                Stopwatch stopwatch = Stopwatch.StartNew();
                                foreach (var kvp in collection.sortedDictionary)
                                {
                                    foreach (Organization item in kvp.Value)
                                    {
                                        if (item.EmployeeCount > employeeCount)
                                        {
                                            res.Add(item);
                                        }
                                    }
                                }
                                stopwatch.Stop();
                                total += stopwatch.ElapsedTicks;
                            }

                            Console.WriteLine($"Время выполнения linq-запроса: {linqTotal / 5}ticks");
                            Console.WriteLine($"Время выполнения расширения: {extensionTotal / 5}ticks");
                            Console.WriteLine($"Время выполнения перебором foreach и проверкой if: {total / 5}");

                            Function.Pause();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("Коллекция: ");
                            Print(collection.sortedDictionary);
                            int res;
                            int employeeCount = Function.InputInteger("Выведется количество организаций у которых сотрудников меньше заданного." +
                                " \n Введите количество сотрудников: ");
                            long linqTotal = 0;
                            for(int i = 0; i < 5; i++)
                            {
                                Stopwatch stopwatch = Stopwatch.StartNew();
                                res = Query.CountLINQ(collection.sortedDictionary, employeeCount);
                                stopWatch.Stop();
                                linqTotal += stopwatch.ElapsedTicks;
                            }

                            res = Query.CountLINQ(collection.sortedDictionary, employeeCount);
                            Console.WriteLine("Количество организаций: " + res);

                            long extensionTotal = 0;
                            for (int i = 0; i < 5; i++)
                            {
                                Stopwatch stopwatch = Stopwatch.StartNew();
                                res = collection.sortedDictionary.CountExtension(el => el.EmployeeCount <= employeeCount);
                                stopWatch.Stop();
                                extensionTotal += stopwatch.ElapsedTicks;
                            }

                            res = collection.sortedDictionary.CountExtension(el => el.EmployeeCount <= employeeCount);
                            Console.WriteLine("Количество организаций: " + res);

                            Console.WriteLine($"Время выполнения linq-запроса: {linqTotal/5}ticks");
                            Console.WriteLine($"Время выполнения расширения: {extensionTotal/5}ticks");

                            Function.Pause();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Коллекция: ");
                            Print(collection.sortedDictionary);
                            GenericCollection newCol = new GenericCollection(3, 3);
                            Print(newCol.sortedDictionary);
                            Console.WriteLine("Выведется объединение всех организаций с типом Государственная.");

                            result = Query.UnionLINQ(collection.sortedDictionary, newCol.sortedDictionary, "Государственная");
                            Console.WriteLine($"Результат {result.Count()} организаций.");
                            foreach (var el in result)
                            {
                                Console.WriteLine(el.ToString() + "\n");
                            }

                            result = collection.sortedDictionary.UnionExtension(newCol.sortedDictionary, "Государственная");
                            Console.WriteLine($"Результат {result.Count()} организаций.");
                            foreach(var el in result)
                            {
                                Console.WriteLine(el.ToString() + "\n");
                            }

                            long linqTotal = 0;
                            for (int i = 0; i < 5; i++)
                            {
                                Stopwatch stopwatch = Stopwatch.StartNew();
                                var linqResult = Query.UnionLINQ(collection.sortedDictionary, newCol.sortedDictionary, "Государственная").ToList();
                                stopwatch.Stop();
                                linqTotal += stopwatch.ElapsedTicks;
                            }

                            long extensionTotal = 0;
                            for (int i = 0; i < 5; i++)
                            {
                                Stopwatch stopwatch = Stopwatch.StartNew();
                                var extensionResult = collection.sortedDictionary.UnionExtension(newCol.sortedDictionary, "Государственная").ToList();
                                stopwatch.Stop();
                                extensionTotal += stopwatch.ElapsedTicks;
                            }

                            Console.WriteLine($"Время выполнения linq-запроса: {linqTotal / 5}ticks");
                            Console.WriteLine($"Время выполнения расширения: {extensionTotal / 5}ticks");

                            Function.Pause();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Коллекция: ");
                            Print(collection.sortedDictionary);
                            Console.WriteLine("Выведется среднее количество сотрудников.");
                            int res;

                            Console.WriteLine("Среднее количество сотрудников: " + Query.AverageLINQ(collection.sortedDictionary));
                            Console.WriteLine("Среднее количество сотрудников: " + collection.sortedDictionary.AverageExtension());

                            long linqTotal = 0;
                            for (int i = 0; i < 5; i++)
                            {
                                Stopwatch stopwatch = Stopwatch.StartNew();
                                res = Query.AverageLINQ(collection.sortedDictionary);
                                stopWatch.Stop();
                                linqTotal += stopwatch.ElapsedTicks;
                            }
                            long extensionTotal = 0;
                            for (int i = 0; i < 5; i++)
                            {
                                Stopwatch stopwatch = Stopwatch.StartNew();
                                res = collection.sortedDictionary.AverageExtension();
                                stopWatch.Stop();
                                extensionTotal += stopwatch.ElapsedTicks;
                            }
                            Console.WriteLine($"Время выполнения linq-запроса: {linqTotal / 5}ticks");
                            Console.WriteLine($"Время выполнения расширения: {extensionTotal / 5}ticks");

                            Function.Pause();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine("Коллекция: ");
                            Print(collection.sortedDictionary);
                            Console.WriteLine("Выведутся группы организаций по типу.");
                            IEnumerable<IGrouping<string, Organization>> group = null;

                            Console.WriteLine("linq-запрос: ");
                            group = Query.GroupLINQ(collection.sortedDictionary);
                            foreach (var signa in group)
                            {
                                Console.WriteLine($"Группа: {signa.Key}, Количество элементов в группе: {signa.Count()}");
                                foreach (var elem in signa)
                                {
                                    Console.WriteLine(elem.ToString() + "\n");
                                }
                            }

                            Console.WriteLine("Расширение: ");
                            group = collection.sortedDictionary.GroupExtension();
                            foreach (var signa in group)
                            {
                                Console.WriteLine($"Группа: {signa.Key}, Количество элементов в группе: {signa.Count()}");
                                foreach (var elem in signa)
                                {
                                    Console.WriteLine(elem.ToString() + "\n");
                                }
                            }

                            long linqTotal = 0;
                            for (int i = 0; i < 5; i++)
                            {
                                Stopwatch stopwatch = Stopwatch.StartNew();
                                var linqResult = Query.GroupLINQ(collection.sortedDictionary).ToList();
                                stopwatch.Stop();
                                linqTotal += stopwatch.ElapsedTicks;
                            }

                            long extensionTotal = 0;
                            for (int i = 0; i < 5; i++)
                            {
                                Stopwatch stopwatch = Stopwatch.StartNew();
                                var extensionResult = collection.sortedDictionary.GroupExtension().ToList();
                                stopwatch.Stop();
                                extensionTotal += stopwatch.ElapsedTicks;
                            }

                            Console.WriteLine($"Время выполнения linq-запроса: {linqTotal / 5}ticks");
                            Console.WriteLine($"Время выполнения расширения: {extensionTotal / 5}ticks");

                            Function.Pause();
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            Console.WriteLine("Дерево: ");
                            orgTree.PrintTree();

                            Console.WriteLine("linq-запрос");
                            result = Query.TreeSelectLINQ(orgTree, "Государственная");
                            Console.WriteLine("Объекты с типом Государственная: ");
                            foreach (var el in result)
                            {
                                Console.WriteLine(el.ToString() + "\n");
                            }

                            Console.WriteLine("Расширение");
                            result = orgTree.TreeSelectExtension(el => el.Type.Contains("Государственная"));
                            Console.WriteLine("Объекты с типом Государственная: ");
                            foreach (var el in result)
                            {
                                Console.WriteLine(el.ToString() + "\n");
                            }

                            Function.Pause();
                            break;
                        }
                    case 7:
                        {
                            Console.Clear();
                            Console.WriteLine("Дерево: ");
                            orgTree.PrintTree();
                            object min = new object();

                            Console.WriteLine("linq-запрос");
                            min = orgTree.TreeAgregateLINQ();
                            Console.WriteLine("Организация с минимальным количеством сотрудников:" + min.ToString() + "\n");

                            Console.WriteLine("Расширение");
                            min = orgTree.TreeAgregateExtension(el => el.EmployeeCount);
                            Console.WriteLine("Организация с минимальным количеством сотрудников:" + min.ToString() + "\n");

                            Function.Pause();
                            break;
                        }
                    case 8:
                        {
                            Console.Clear();
                            Console.WriteLine("Дерево: ");
                            orgTree.PrintTree();

                            Console.WriteLine("linq-запрос");
                            result = Query.TreeOrderByDescendingLINQ(orgTree);
                            Console.WriteLine("Отсортированная в обратном порядке по количеству сотрудников последовательность: ");
                            foreach (var el in result)
                            {
                                Console.WriteLine(el.ToString() + "\n");
                            }

                            Console.WriteLine("Расширение");
                            result = orgTree.TreeOrderByDescendingExtension(el => el.EmployeeCount);
                            Console.WriteLine("Отсортированная в обратном порядке по количеству сотрудников последовательность: ");
                            foreach (var el in result)
                            {
                                Console.WriteLine(el.ToString() + "\n");
                            }

                            Function.Pause();
                            break;
                        }
                    default:
                        Console.WriteLine("Выберите из списка");
                        break;
                }
            } while (choice != 0);
        }
        static void Print(SortedDictionary<int, Queue<Organization>> collection)
        {
            int i = 0;
            foreach (var v in collection)
            {
                Console.WriteLine($"\t Коллекция {++i}");
                foreach (var elem in v.Value)
                {
                    Console.WriteLine(elem.ToString() + "\n");
                }
            }
        }
        static void Main(string[] args)
        {
            Menu();
        }

    }
}
