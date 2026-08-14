using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationLib
{
    public class ShipbuildingСompany : Factory
    {
        private int shipCount;

        public int ShipCount
        {
            get => shipCount;
            set
            {
                if (value >= 0)
                    shipCount = value;
                else
                    throw new Exception("Ошибка, значение не может быть отрицательным!");
            }
        }

        public ShipbuildingСompany() : base()
        {
            ShipCount = 0;
        }

        public ShipbuildingСompany(string type, int employeeCount, int departmentCount, int shipCount) : base(type, employeeCount, departmentCount)
        {
            ShipCount = shipCount;
        }

        public override void Show()
        {
            Console.WriteLine("\n\t\"<Судостроительная компания>\"");
            base.Show();
            Console.WriteLine($"Количество кораблей:{ShipCount}");
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите количество кораблей:");
            bool ok = Int32.TryParse(Console.ReadLine(), out shipCount);
            while (!ok)
            {
                Console.WriteLine("Неверный ввод, попробуйте снова:");
                ok = Int32.TryParse(Console.ReadLine(), out shipCount);
            }
        }

        public override void RandInit()
        {
            base.RandInit();
            ShipCount = random.Next(0, 20000);
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                ShipbuildingСompany ship = (ShipbuildingСompany)obj;
                return (Type == ship.Type) && (EmployeeCount == ship.EmployeeCount) 
                    && (DepartmentCount == ship.DepartmentCount) && (ShipCount == ship.ShipCount);
            }
        }
        public override int GetHashCode()
        {
            int hashCode = -1360180430;
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            hashCode = hashCode * -1521134295 + EmployeeCount.GetHashCode();
            hashCode = hashCode * -1521134295 + DepartmentCount.GetHashCode();
            hashCode = hashCode * -1521134295 + ShipCount.GetHashCode();
            return hashCode;
        }
    }
}
