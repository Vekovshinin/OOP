using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationLib
{
    public class Library : Organization
    {
        private int textbookCount;

        public int TextbookCount
        {
            get => textbookCount;
            set
            {
                if (value >= 0)
                    textbookCount = value;
                else
                    throw new Exception("Ошибка, значение не может быть отрицательным!");
            }
        }

        public Library() : base()
        {
            TextbookCount = 0;
        }

        public Library(string type, int employeeCount, int textbookCount) : base(type, employeeCount)
        {
            TextbookCount = textbookCount;
        }

        public override void Show()
        {
            Console.WriteLine("\n\t\"<Библиотека>\"");
            base.Show();
            Console.WriteLine($"Количество учебников:{TextbookCount}");
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите количество учебников в библиотеке: ");
            bool ok = Int32.TryParse(Console.ReadLine(), out textbookCount);
            while (!ok)
            {
                Console.WriteLine("Неверный ввод, попробуйте снова:");
                ok = Int32.TryParse(Console.ReadLine(), out textbookCount);
            }
        }

        public override void RandInit()
        {
            base.RandInit();
            TextbookCount = random.Next(0, 20000);
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Library lib = (Library)obj;
                return (Type == lib.Type) && (EmployeeCount == lib.EmployeeCount) && (TextbookCount == lib.TextbookCount);
            }
        }
        public override int GetHashCode()
        {
            int hashCode = -1360180430;
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            hashCode = hashCode * -1521134295 + EmployeeCount.GetHashCode();
            hashCode = hashCode * -1521134295 + TextbookCount.GetHashCode();
            return hashCode;
        }
    }
}
