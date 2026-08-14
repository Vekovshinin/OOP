using System;
using System.Xml.Serialization;

namespace OrganizationLib
{
    [Serializable]
    [XmlInclude(typeof(InsuranceСompany))]
    public class Organization : IInit, ICloneable, IComparable<Organization>
    {
        private string type;
        private int employeeCount;
        public int[] testClon = { 1, 2, 3 }; // ссылочный тип для демонстрации клонирования 

       protected static Random random = new Random();    

        public string Type
        {
            get => type;
            set => type = value;
        }

        public int EmployeeCount
        {
            get => employeeCount;
            set
            {
                if (value >= 0)
                    employeeCount = value;
                else
                    throw new Exception("Ошибка! Значение не может быть отрицательным");
            }
        }

        public Organization()
        {
            EmployeeCount = 0;
            Type = "";
        }

        public Organization(string type, int employeeCount)
        {
            Type = type;
            EmployeeCount = employeeCount;
        }

        public virtual void Show()
        {
            Console.WriteLine("\n\t\"Организация\"");
            Console.WriteLine($"Тип:{Type}\nКоличество сотрудников:{EmployeeCount}");
        }

        public virtual void Init()
        {
            Console.WriteLine("Введите тип организации: ");
            Type = Console.ReadLine();
            bool ok = Int32.TryParse(Console.ReadLine(), out employeeCount);
            while (!ok)
            {
                Console.WriteLine("Неверный ввод, попробуйте снова:");
                ok = Int32.TryParse(Console.ReadLine(), out employeeCount);
            }
        }

        public virtual void RandInit()
        {
            Type = RandomType();
            EmployeeCount = random.Next(1,5000);
        }

        private string RandomType()
        {
            string[] word = { "Государственная", "Коммерческая", "Партнерская"};
            return word[random.Next(0, word.Length)];
        }

        public Organization ShallowCopy() //поверхностное копирование
        {
            return (Organization)this.MemberwiseClone();
        }

        public object Clone()
        {
            return new Organization(Type, EmployeeCount);
        }
        public int CompareTo(Organization other)
        {
            Organization temp = (Organization)other;
            if (EmployeeCount > temp.EmployeeCount)
                return 1;
            if (EmployeeCount < temp.EmployeeCount)
                return -1;
            return 0;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Organization org = (Organization)obj;
                return (Type == org.Type) && (EmployeeCount == org.EmployeeCount);
            }
        }
        public override int GetHashCode()
        {
            int hashCode = -1360180430;
            hashCode = hashCode * -1521134295 + Type.GetHashCode(); 
            hashCode = hashCode * -1521134295 + EmployeeCount.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return $"Организация : Тип:{Type} : Количество сотрудников:{EmployeeCount}";
        }
    }
}
