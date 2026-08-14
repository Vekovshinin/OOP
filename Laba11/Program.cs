using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using OrganizationLib;

namespace Laba11
{
    public class Program
    {
        public static string TimeOfWorkQueue<T>(Queue<T> queue, T obj)
        {
            bool isContains = false;
            long totalTicks = 0;
            for (int i = 0; i < 5; i++)
            {
                Stopwatch stopW = new Stopwatch();

                stopW.Start();
                isContains = queue.Contains(obj);
                stopW.Stop();
                totalTicks += stopW.Elapsed.Ticks;
            }
            long ts = totalTicks / 5;
            string elapsedTime = $"{ts} Найден: {isContains}";

            return elapsedTime;
        }

        public static string TimeOfWorkSortedDictionary<TKey, TValue>(SortedDictionary<TKey, TValue> sortDictionary, TKey key)
        {
            bool isContains = false;
            long totalTicks = 0;
            for (int i = 0; i < 5; i++)
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();
                isContains = sortDictionary.ContainsKey(key);
                stopwatch.Stop();
                totalTicks += stopwatch.Elapsed.Ticks;
            }
            long ts = totalTicks / 5;
            string elapsedTime = $"{ts} Найден: {isContains}";
            return elapsedTime;
        }

        public static string TimeOfWorkSortedDictionary<TKey, TValue>(SortedDictionary<TKey, TValue> sortDictionary, TValue value)
        {
            bool isContains = false;
            long totalTicks = 0;
            for (int i = 0; i < 5; i++)
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();
                isContains = sortDictionary.ContainsValue(value);
                stopwatch.Stop();
                totalTicks += stopwatch.Elapsed.Ticks;
            }
            long ts = totalTicks / 5;
            string elapsedTime = $"{ts} Найден: {isContains}";
            return elapsedTime;
        }

        public static void TestTime(ref TestCollections test)
        {
            
            Console.WriteLine("Поиск первого элемента в коллекции Queue<Organization>...");
            Console.WriteLine($"Время = {TimeOfWorkQueue(test.queueOrganization, (Organization)test.queueOrganization.Peek().Clone())}");
            Console.WriteLine("Поиск центрального элемента в коллекции Queue<Organization>...");
            Console.WriteLine($"Время = {TimeOfWorkQueue(test.queueOrganization, (Organization)test.queueOrganization.ElementAt(test.queueOrganization.Count / 2).Clone())}");
            Console.WriteLine("Поиск последнего элемента в коллекции Queue<Organization>...");
            Console.WriteLine($"Время = {TimeOfWorkQueue(test.queueOrganization, (Organization)test.queueOrganization.ElementAt(test.queueOrganization.Count - 1).Clone())}");
            Console.WriteLine("Поиск элемента не входящего в коллекцию Queue<Organization>...");
            Console.WriteLine($"Время = {TimeOfWorkQueue(test.queueOrganization, new Organization())}");
            Console.WriteLine();

            Console.WriteLine("Поиск первого элемента в коллекции Queue<string>...");
            Console.WriteLine($"Время = {TimeOfWorkQueue(test.queueString, (string)test.queueString.Peek().Clone())}");
            Console.WriteLine("Поиск центрального элемента в коллекции Queue<string>...");
            Console.WriteLine($"Время = {TimeOfWorkQueue(test.queueString, (string)test.queueString.ElementAt(test.queueString.Count / 2).Clone())}");
            Console.WriteLine("Поиск последнего элемента в коллекции Queue<string>...");
            Console.WriteLine($"Время = {TimeOfWorkQueue(test.queueString, (string)test.queueString.ElementAt(test.queueString.Count - 1).Clone())}");
            Console.WriteLine("Поиск элемента не входящего в коллекцию Queue<string>...");
            Console.WriteLine($"Время = {TimeOfWorkQueue(test.queueString, "")}");
            Console.WriteLine();

            Console.WriteLine("Поиск первого ключа в коллекции SortedDictionary<Organization, InsuranceСompany>...");
            Console.WriteLine($"Время = {TimeOfWorkSortedDictionary(test.sortedDictionaryOrganizationInsuranceСompany, (Organization)test.sortedDictionaryOrganizationInsuranceСompany.Keys.ToArray()[0]).Clone()}");
            Console.WriteLine("Поиск центрального ключа в коллекции SortedDictionary<Organization, InsuranceСompany>...");
            Console.WriteLine($"Время = {TimeOfWorkSortedDictionary(test.sortedDictionaryOrganizationInsuranceСompany, (Organization)test.sortedDictionaryOrganizationInsuranceСompany.Keys.ToArray()[test.sortedDictionaryOrganizationInsuranceСompany.Keys.Count / 2]).Clone()}");
            Console.WriteLine("Поиск последнего ключа в коллекции SortedDictionary<Organization, InsuranceСompany>...");
            Console.WriteLine($"Время = {TimeOfWorkSortedDictionary(test.sortedDictionaryOrganizationInsuranceСompany, (Organization)test.sortedDictionaryOrganizationInsuranceСompany.Keys.ToArray()[test.sortedDictionaryOrganizationInsuranceСompany.Keys.Count - 1]).Clone()}");
            Console.WriteLine("Поиск ключа не входящего в коллекцию SortedDictionary<Organization, InsuranceСompany>...");
            Console.WriteLine($"Время = {TimeOfWorkSortedDictionary(test.sortedDictionaryOrganizationInsuranceСompany, new Organization())}");
            Console.WriteLine();

            Console.WriteLine("Поиск первого ключа в коллекции SortedDictionary<string,InsuranceСompany>...");
            Console.WriteLine($"Время = {TimeOfWorkSortedDictionary(test.sortedDictionaryStringInsuranceСompany, (string)test.sortedDictionaryStringInsuranceСompany.Keys.ToArray()[0]).Clone()}");
            Console.WriteLine("Поиск центрального ключа в коллекции SortedDictionary<string,InsuranceСompany>...");
            Console.WriteLine($"Время = {TimeOfWorkSortedDictionary(test.sortedDictionaryStringInsuranceСompany, (string)test.sortedDictionaryStringInsuranceСompany.Keys.ToArray()[test.sortedDictionaryStringInsuranceСompany.Keys.Count / 2]).Clone()}");
            Console.WriteLine("Поиск последнего ключа в коллекции SortedDictionary<string,InsuranceСompany>...");
            Console.WriteLine($"Время = {TimeOfWorkSortedDictionary(test.sortedDictionaryStringInsuranceСompany, (string)test.sortedDictionaryStringInsuranceСompany.Keys.ToArray()[test.sortedDictionaryStringInsuranceСompany.Keys.Count - 1]).Clone()}");
            Console.WriteLine("Поиск ключа не входящего в коллекцию SortedDictionary<string,InsuranceСompany>...");
            Console.WriteLine($"Время = {TimeOfWorkSortedDictionary(test.sortedDictionaryStringInsuranceСompany, "")}");
            Console.WriteLine();

            Console.WriteLine("Поиск первого элемента в коллекции SortedDictionary<string,InsuranceСompany>...");
            Console.WriteLine($"Время = {TimeOfWorkSortedDictionary(test.sortedDictionaryStringInsuranceСompany, (InsuranceСompany)test.sortedDictionaryStringInsuranceСompany.Values.ToArray()[0]).Clone()}");
            Console.WriteLine("Поиск центрального элемента в коллекции SortedDictionary<string,InsuranceСompany>...");
            Console.WriteLine($"Время = {TimeOfWorkSortedDictionary(test.sortedDictionaryStringInsuranceСompany, (InsuranceСompany)test.sortedDictionaryStringInsuranceСompany.Values.ToArray()[test.queueOrganization.Count / 2]).Clone()}");
            Console.WriteLine("Поиск последнего элемента в коллекции SortedDictionary<string,InsuranceСompany>...");
            Console.WriteLine($"Время = {TimeOfWorkSortedDictionary(test.sortedDictionaryStringInsuranceСompany, test.sortedDictionaryStringInsuranceСompany.Values.ToArray()[test.queueOrganization.Count - 1]).Clone()}");
            Console.WriteLine("Поиск элемента не входящего в коллекцию SortedDictionary<string,InsuranceСompany>...");
            Console.WriteLine($"Время = {TimeOfWorkSortedDictionary(test.sortedDictionaryStringInsuranceСompany, new InsuranceСompany())}");
        }
        public static void PrintMenu()
        {
            Console.WriteLine("1. Добавить элементы\n2. Время поиска в различных коллекциях\n3. Выход");
        }

        static void Main(string[] args)
        {
            TestCollections test = new TestCollections();
            while (true)
            {
                PrintMenu();
                int choice = Function.InputInteger("Введите число: ");
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        int count = Function.InputInteger("Введите количество элементов для добавления: ");
                        test.RandInit(count);
                        break;
                    case 2:
                        Console.Clear();
                        try
                        {
                            TestTime(ref test);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("В коллекции отсутствуют элементы\n");
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Выберите из списка");
                        break;
                }
            }
        }
    }
}
