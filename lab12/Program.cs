using Laba11;
using OrganizationLib;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public class Program
    {
        static void Menu()
        {
            int choice;
            Tree<Organization> myCollections = new Tree<Organization>();
            do
            {
                Console.Clear();
                Console.WriteLine("0. Выход\n" +
                    "1. Добавление одного или нескольких элементов в коллекцию\n" +
                    "2. Удаление элемента из коллекции\n" +
                    "3. Поиск элемента по значению\n" +
                    "4. Печать коллекции\n" +
                    "5. Печать коллекции циклом foreach\n" +
                    "6. Глубокое клонирование коллекции\n" +
                    "7. Поверхностное копирование коллекции\n" +
                    "8. Удаление коллекции из памяти\n");
                choice = Function.InputInteger("Введите число: ");
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Завершение работы программы");
                        break;
                    case 1:
                        {
                            Console.Clear();
                            int countEl = Function.InputInteger("Введите количество добавляемых элементов: ");
                            Function.CheckNumber(1, 100, ref countEl);
                            for (int i = 0; i < countEl; ++i)
                            {
                                Organization org = new Organization();
                                org.RandInit();
                                myCollections.Add(org);
                            }
                            Function.Pause();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("Для демонстрации удаления сначала создадим новый объект, добавим его в коллекцию, затем удалим.");
                            Organization org = new Organization();
                            org.RandInit();
                            Console.WriteLine("Новый элемент: ");
                            org.Show();

                            myCollections.Add(org);
                            Console.WriteLine("Дерево до удаления");
                            myCollections.PrintTree();
                            myCollections.Remove(org);
                            Console.WriteLine("Дерево после удаления: ");
                            myCollections.PrintTree();
                            Function.Pause();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Для демонстрации поиска элемента, сначала создадим новый объект, добавим его в коллекцию, и выполним поиск");
                            Organization org = new Organization();
                            org.RandInit();
                            Console.WriteLine("Новый элемент: ");
                            org.Show();

                            myCollections.Add(org);
                            Console.WriteLine("Коллекция после добавления");
                            myCollections.PrintTree();

                            if (myCollections.Contains(org))
                            {
                                Console.WriteLine("Объект найден");
                            }
                            Console.WriteLine("Удалим объект из коллекции: ");
                            if (myCollections.Remove(org))
                            {
                                Console.WriteLine("Коллекция после удаления: ");
                                myCollections.PrintTree();
                            }
                            Console.WriteLine();
                            if (!myCollections.Contains(org))
                            {
                                Console.WriteLine("Объект не найден");
                            }
                            Function.Pause();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            myCollections.PrintTree();
                            Function.Pause();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine("Обход с помощью цикла foreach");
                            foreach(Organization item in myCollections)
                            {
                                item.Show();
                            }
                            Function.Pause();
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            if (myCollections.Count != 0)
                            {
                                Tree<Organization> myCollectionClone = new Tree<Organization>(myCollections);
                                Tree<Organization> shallowCopyOrganizawion = myCollections.ShallowCopy();
                                Console.WriteLine("Для демонстрации глубокого клонирования коллекции, " +
                                    "создадим клон, затем изменяем элемент в исходной коллекции, затем выводим коллекцию и клон");
                                myCollections.ElementAt(0).Show();
                                myCollections.ElementAt(0).EmployeeCount = 0;
                                myCollections.ElementAt(0).Show();
                                Console.WriteLine("Исходная коллекция");
                                myCollections.PrintTree();
                                Console.WriteLine("Клон");
                                myCollectionClone.PrintTree();
                                Console.WriteLine("Поверхностная копия");
                                shallowCopyOrganizawion.PrintTree();
                            }
                            Function.Pause();
                            break;
                        }
                    case 7:
                        {
                            Console.Clear();
                            Tree<Organization> myCollectionClone = new Tree<Organization>(myCollections);
                            Tree<Organization> shallowCopyOrg = myCollections.ShallowCopy();
                            Console.WriteLine("Для демонстрации поверхностного копирования коллекции, создадим копию коллекции, затем в исходную коллекцию добавляем новый элемент, затем выводим коллекцию и копию коллекции");
                            Organization org = new Organization();
                            org.RandInit();
                            Console.WriteLine("Новый элемент: ");
                            org.Show();

                            Console.WriteLine("Исходна коллекция до добавления:");
                            myCollections.PrintTree();
                            Console.WriteLine("Поверхностная копия до добавления: ");
                            shallowCopyOrg.PrintTree();
                            Console.WriteLine("Клон до добавления: ");
                            myCollectionClone.PrintTree();
                            myCollections.Add(org);
                            Console.WriteLine("Исходна коллекция после добавления:");
                            myCollections.PrintTree();
                            Console.WriteLine("Поверхностная копия после добавления:");
                            shallowCopyOrg.PrintTree();
                            Console.WriteLine("Клон после добавления: ");
                            myCollectionClone.PrintTree();
                            if (myCollections.Remove(org))
                            {
                                Console.WriteLine("Объект удален");
                            }
                            Function.Pause();
                            break;
                        }
                    case 8:
                        {
                            Console.Clear();
                            myCollections.Clear();
                            Console.WriteLine("Коллекция удалена");
                            Function.Pause();
                            break;
                        }
                    default:
                        Console.WriteLine("Выберите из списка:");
                        break;

                }

            } while (choice != 0);

        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}
