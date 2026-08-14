using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrganizationLib
{
    [Serializable]
    
    public class InsuranceСompany : Organization
    {
        private int insuranceFund;

        public int InsuranceFund
        {
            get => insuranceFund;
            set
            {
                if (value >= 0)
                {
                    insuranceFund = value;
                }
                else
                {
                    throw new Exception("Ошибка, значение не может быть отрицательным!");
                }
            }
        }

        public InsuranceСompany() : base()
        {
            InsuranceFund = 0;
        }

        public InsuranceСompany(string type, int employeeCount, int numContact) : base(type, employeeCount)
        {
            InsuranceFund = numContact;
        }
        public override void Show()
        {
            Console.WriteLine("\n\t\"<Страховая компания>\"");
            base.Show();
            Console.WriteLine($"Страховой фонд:{InsuranceFund}");
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите страховой фонд компании: ");
            bool ok = Int32.TryParse(Console.ReadLine(), out insuranceFund);
            while (!ok)
            {
                Console.WriteLine("Неверный ввод, попробуйте снова:");
                ok = Int32.TryParse(Console.ReadLine(), out insuranceFund);
            }
        }
        public override void RandInit()
        {
            base.RandInit();
            InsuranceFund = random.Next(1, 20000000);
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                InsuranceСompany ins = (InsuranceСompany)obj;
                return (Type == ins.Type) && (EmployeeCount == ins.EmployeeCount) && (InsuranceFund == ins.InsuranceFund);
            }
        }
        public override int GetHashCode()
        {
            int hashCode = -1360180430;
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            hashCode = hashCode * -1521134295 + EmployeeCount.GetHashCode();
            hashCode = hashCode * -1521134295 + InsuranceFund.GetHashCode();
            return hashCode;
        }

        public Organization BaseOrganization
        {
            get
            {
                return new Organization(Type, EmployeeCount); //возвращает объект базового класса
            }
        }

        public override string ToString()
        {
            return $"Страховая компания Тип: {Type}: Количество сотрудников: {EmployeeCount}: Страховой фонд : {InsuranceFund}";
        }
    }
}
