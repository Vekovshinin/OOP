using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationLib
{
    public interface IInit
    {
        void Show();
        void Init();
        void RandInit(); 
    }

    public class Animal : IInit
    {
        string name;
        int weight;

        static Random random = new Random();

        public string Name { get; set; }
        public int Weight { get; set; }

        public Animal()
        {
            Name = "NULL";
            Weight = 0;
        }

        public Animal(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public void Init()
        {
            Console.WriteLine("\t\"Животное\"");
            Console.Write("Название животного: ");
            Name = Console.ReadLine();
            Console.WriteLine("Введите вес животного: ");
            bool ok = Int32.TryParse(Console.ReadLine(), out weight);
            while (!ok)
            {
                Console.WriteLine("Неверный ввод, попробуйте снова:");
                ok = Int32.TryParse(Console.ReadLine(), out weight);
            }
        }

        public void RandInit()
        {
            Name = RandomName();
            Weight = RandomWeight();
        }
        private string RandomName()
        {
            string[] words = { "Зебра", "Кошка", "Лев", "Кролик" };
            return words[random.Next(0, words.Length)];
        }
        private int RandomWeight()
        {
            return random.Next(5, 100);
        }

        public void Show()
        {
            Console.WriteLine("\t\"Животное\"");
            Console.WriteLine($"Название: {Name}\nВес:{Weight}");
        }
    }
}
