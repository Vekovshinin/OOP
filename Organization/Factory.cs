using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrganizationLib
{
    public class Factory : Organization
    {
        private int departmentCount;

        public int DepartmentCount
        {
            get => departmentCount;
            set
            {
                if (value >= 0)
                    departmentCount = value;
                else
                    throw new Exception("Ошибка, значение не может быть отрицательным");
            }
        }

        public Factory() : base()
        {
            DepartmentCount = 0;
        }

        public Factory(string type, int employeeCount, int departmentCount) : base(type, employeeCount)
        {
            DepartmentCount = departmentCount;
        }

        public override void Show()
        {
            Console.WriteLine("\n\t\"<Завод>\"");
            base.Show();
            Console.WriteLine($"Количество цехов:{DepartmentCount}");
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите количество цехов на заводе: ");
            bool ok = Int32.TryParse(Console.ReadLine(), out departmentCount);
            while (!ok)
            {
                Console.WriteLine("Неверный ввод, попробуйте снова:");
                ok = Int32.TryParse(Console.ReadLine(), out departmentCount);
            }
        }

        public override void RandInit()
        {
            base.RandInit();
            DepartmentCount = random.Next(1, 2000);
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Factory fact = (Factory)obj;
                return (Type == fact.Type) && (EmployeeCount == fact.EmployeeCount) && (DepartmentCount == fact.DepartmentCount);
            }
        }
        public override int GetHashCode()
        {
            int hashCode = -1360180430;
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            hashCode = hashCode * -1521134295 + EmployeeCount.GetHashCode();
            hashCode = hashCode * -1521134295 + DepartmentCount.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return $"Фабрика Тип: {Type}: Количество сотрудников: {EmployeeCount}: Количество цехов : {DepartmentCount}";
        }
    }
}
