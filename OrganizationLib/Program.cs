using OrganizationLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Laba10
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Organization[] organizations = new Organization[30];
            for (int i = 0; i < 10; i++)
            {
                organizations[i] = new Organization();
                organizations[i].RandInit();
            }
            for(int i = 10;i < 15; i++)
            {
                organizations[i] = new InsuranceСompany();
                organizations[i].RandInit();
            }
            for(int i = 15; i < 20; i++)
            {
                organizations[i] = new Factory();
                organizations[i].RandInit();
            }
            for (int i = 20; i < 25; i++) 
            {
                organizations[i] = new ShipbuildingСompany();
                organizations[i].RandInit();
            }

            for (int i = 25; i < 30; i++)
            {
                organizations[i] = new Library();
                organizations[i].RandInit();
            }

            IInit[] inits = new IInit[20];
            for (int i = 0; i < 10; ++i)
            {
                inits[i] = new Animal();
                inits[i].RandInit();
            }
            for (int i = 10; i < 15; ++i)
            {
                inits[i] = new Organization();
                inits[i].RandInit();
            }
            for (int i = 15; i < 20; ++i)
            {
                inits[i] = new Factory();
                inits[i].RandInit();
            }

            int choice;
            do
            {
                Console.Clear();
                Console.Write("1. Первая часть (наследование и полиморфизм)\n" +
                    "2. Вторая часть (динамическая идентификация типов)\n" +
                    "3. Третья часть (интерфейс)\n" +
                    "4. Выход\n");
                choice = Function.InputInteger("Введите число: ");
                Function.CheckNumber(1, 4, ref choice);
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Демонстрация наследования");
                        Organization org = new Organization();
                        org.RandInit();
                        InsuranceСompany insuranceСompany = new InsuranceСompany();
                        insuranceСompany.RandInit();
                        Factory factory = new Factory();
                        factory.RandInit();
                        ShipbuildingСompany shipCompany = new ShipbuildingСompany();
                        shipCompany.RandInit();
                        Library library = new Library();
                        library.RandInit();
                        Organization[] demonstationOrganization = { org, insuranceСompany, factory, shipCompany, library};
                        foreach (var l in demonstationOrganization)
                        {
                            l.Show();
                        }
                        Function.Pause();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\t\"Запросы\"");
                        Console.Write("1. Суммарный страховой фонд страховых компаний у которых количество сотрудников > 2500 \n" +
                            "2. Количество кораблей, выпущенных всеми судостроительными компаниями\n" +
                            "3. Подсчет библиотек с заданным типом \n");
                        int count = 0;
                        int choice1 = Function.InputInteger();
                        Function.CheckNumber(1, 3, ref choice1);
                        switch (choice1)
                        {
                            case 1:
                                count = SumInsuranceFunds(organizations);
                                Console.WriteLine("\nСумарный страховой фонд страховых компаний у которых количество сотрудников > 2500: ");
                                Console.WriteLine(count);
                                break;
                            case 2:
                                count = SumShips(organizations);
                                Console.WriteLine("\nКоличество кораблей, выпущенных всеми судостроительными компаниями: ");
                                Console.WriteLine(count);
                                break;
                            case 3:
                                count = CountSpecifiedTypeLibrary(organizations);
                                Console.WriteLine("\nПодсчет библиотек с заданным типом: ");
                                Console.WriteLine(count);
                                break;
                        }
                        Function.Pause();
                        break;                   
                    case 3:
                        choice1 = 0;
                        do
                        {
                            Console.Clear();
                            Console.Write("0. Вернуться к общему меню\n" +
                                "1. Отсортировать массив объектов по типу (используя Array.Sort(organizations, SortByType());)\n" +
                                "2. Отсортировать массив объектов по количеству сотрудников (используя Array.Sort(organizations, new SortByEmployeeCount());)\n" +
                                "3. Бинарный поиск по количеству сотрудников (используя Array.BinarySearch(organizations, orgForSearch, new BinarySearchByEmployeeCount());) \n" +
                                "4. Просмотр массива элементов типа IInit\n" +
                                "5. Демонстрация работы методов клонирования IClonable\n" +
                                "6. Вывод массива объектов\n");
                            choice1 = Function.InputInteger();
                            Function.CheckNumber(0, 6, ref choice1);
                            switch (choice1)
                            {
                                case 1:
                                    Array.Sort(organizations, new SortByType());
                                    Console.WriteLine("Сортировка по типу организации:");
                                    ShowOrganizations(organizations);
                                    Function.Pause();
                                    break;
                                case 2:
                                    Console.WriteLine("Сортировка по количеству сотрудников");
                                    Array.Sort(organizations, new SortByEmployeeCount());
                                    ShowOrganizations(organizations);
                                    Function.Pause();
                                    break;
                                case 3:
                                    int employeeCount = Function.InputInteger("Введите количество сотрудников (от 1 до 5000)");
                                    Function.CheckNumber(1, 5000, ref employeeCount);
                                    Organization orgForSearch = new Organization() { EmployeeCount = employeeCount };
                                    Array.Sort(organizations);
                                    int res = Array.BinarySearch(organizations, orgForSearch, new BinarySearchByEmployeeCount());
                                    if (res <  0)
                                        Console.WriteLine($"Организация с количеством сотрудников равным {employeeCount} не была найдена!\n");
                                    else
                                    {
                                        Console.WriteLine($"Индекс элемента с количеством сотрудников {employeeCount} - {res}");
                                        organizations[res].Show();
                                    }
                                    Function.Pause();
                                    break;
                                case 4:
                                    Console.WriteLine("Массив элементов типа IInit");
                                    foreach (var item in inits)
                                    {
                                        item.Show();
                                        Console.WriteLine();
                                    }
                                    Function.Pause();
                                    break;
                                case 5:

                                    Organization test = new Organization();
                                    Organization test2 = (Organization)test.Clone();
                                    Organization test3 = test.ShallowCopy();
                                    Console.WriteLine("Organization test = new Organization();\nOrganization test2 = (Organization)test.Clone();\nOrganization test3 = test.ShallowCopy();");
                                    Console.WriteLine("public int[] testClon = { 1, 2, 3 };\nИзначально ссылочный тип в классе Organization = {1, 2, 3} ");
                                    Console.WriteLine("test.testClon[0] = 9;");
                                    test.testClon[0] = 9;
                                    Console.WriteLine("После изменения ссылочного типа: {9, 2, 3}");
                                    Console.WriteLine($"Глубокое копирование первого элемента (Clone) (test2.testClon[0]): {test2.testClon[0]}\nПоверхностное копирование первого элемента (ShallowCopy)(test3.testClon[0]): {test3.testClon[0]}\n");
                                    Function.Pause();
                                    break;
                                case 6:
                                    ShowOrganizations(organizations);
                                    Function.Pause();
                                    break;
                            }
                        } while (choice1 > 0);
                        break;
                    case 4:
                        Console.WriteLine("Завершение работы программы");
                        break;
                    default:
                        Console.WriteLine("Выберите из списка");
                        break;
                }
            } while (choice != 4);
        }

        public static int SumInsuranceFunds(Organization[] organizations)
        {
            int sum = 0;
            foreach(var item in  organizations)
            {
                if (item is  InsuranceСompany)
                {
                    if (((InsuranceСompany)item).EmployeeCount > 2500)
                    {
                        sum += ((InsuranceСompany)item).InsuranceFund;
                        item.Show();
                    }
                }
            }
            return sum;
        }

        public static int SumShips(Organization[] organizations)
        {
            int sum = 0;
            foreach(var item in organizations)
            {
                if (item is ShipbuildingСompany)
                {
                    sum += ((ShipbuildingСompany)item).ShipCount;
                    item.Show();
                }
            }
            return sum;
        }

        public static int CountSpecifiedTypeLibrary(Organization[] organizations)
        {
            Console.WriteLine("Введите тип из списка: Государственная, Коммерческая, Партнерская");
            string type = Console.ReadLine();
            int count = 0;
            foreach (var item in organizations)
            {
                if (item is  Library)
                {
                    if (((Library)item).Type == type)
                    {
                        count++;
                        item.Show();
                    }
                }
            }
            return count;
        }
        public static void ShowOrganizations(Organization[] organizations)
        {
            foreach (var item in organizations)
            {
                item.Show();
                Console.WriteLine();
            }
        }
    }
}
