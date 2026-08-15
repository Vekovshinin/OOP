using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Laba10;
using System.IO;
using OrganizationLib;
using System.Linq;
using System.ComponentModel.Design;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        // тест Organization
        [TestMethod]
        public void EmployeeCountThrowsException()
        {
            var organization = new Organization();

            var exception = Assert.ThrowsException<Exception>(() => organization.EmployeeCount = -1);
            Assert.AreEqual("Ошибка! Значение не может быть отрицательным", exception.Message);
        }

        [TestMethod]
        public void TestCloneOrganization()
        {
            var organization = new Organization("Государственная", 200);

            var clonedOrganization = (Organization)organization.Clone();

            Assert.AreNotSame(organization, clonedOrganization);
            Assert.AreEqual(organization.Type, clonedOrganization.Type);
            Assert.AreEqual(organization.EmployeeCount, clonedOrganization.EmployeeCount);
        }

        [TestMethod]
        public void TestShallowCopyOrganization()
        {
            var organization = new Organization("Государственная", 200);

            var copyOrganization = organization.ShallowCopy();

            Assert.AreNotSame(organization, copyOrganization);
            Assert.AreEqual(organization.Type, copyOrganization.Type);
            Assert.AreEqual(organization.EmployeeCount, copyOrganization.EmployeeCount);
        }

        [TestMethod]
        public void CompareToReturnsZero()
        {
            var org1 = new Organization("Type1", 100);
            var org2 = new Organization("Type2", 100);

            int result = org1.CompareTo(org2);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareToReturnsPositive()
        {
            var org1 = new Organization("Type1", 200);
            var org2 = new Organization("Type2", 100);

            int result = org1.CompareTo(org2);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CompareToReturnsNegative()
        {
            var org1 = new Organization("Type1", 100);
            var org2 = new Organization("Type2", 200);

            int result = org1.CompareTo(org2);

            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void EqualsReturnsTrue()
        {
            var org1 = new Organization("Type1", 100);
            var org2 = new Organization("Type1", 100);

            bool result = org1.Equals(org2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EqualsReturnsFalse()
        {
            var org1 = new Organization("type1", 100);
            var org2 = new Organization("type2", 200);
            bool result = org1.Equals(org2);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void EqualsNullObj()
        {
            var org1 = new Organization("Type1", 100);
            var org2 = new Organization();
            bool result = org1.Equals(org2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetHashCodeReturnsSameHashCodeOrganization()
        {
            var org1 = new Organization { Type = "Type1", EmployeeCount = 100 };
            var org2 = new Organization { Type = "Type1", EmployeeCount = 100 };

            int hash1 = org1.GetHashCode();
            int hash2 = org2.GetHashCode();

            Assert.AreEqual(hash1, hash2, "Hash codes should be equal for equal objects.");
        }

        // тест InsruanceCompany
        [TestMethod]
        public void InsuranceFundThrowsException()
        {
            var insuranceCompany = new InsuranceСompany();

            var exception = Assert.ThrowsException<Exception>(() => insuranceCompany.InsuranceFund = -1);
            Assert.AreEqual("Ошибка, значение не может быть отрицательным!", exception.Message);
        }
        
        [TestMethod]
        public void InsuranceFundRight()
        {
            var insuranceCompany = new InsuranceСompany("Type1", 100, 500000);
            Assert.AreEqual(500000,insuranceCompany.InsuranceFund);     
        }
        [TestMethod]
        public void TestBaseOrganization()
        {
            var ins = new InsuranceСompany("Type1", 500, 500000);
            var org = new Organization();
            org =  ins.BaseOrganization;
            Assert.AreEqual("Type1", org.Type);
            Assert.AreEqual(500, org.EmployeeCount);
        }
        [TestMethod]
        public void EqualsReturnsTrueInsruanceCompany()
        {
            var company1 = new InsuranceСompany("Type1", 100, 5000000);
            var company2 = new InsuranceСompany("Type1", 100, 5000000);

            bool result = company1.Equals(company2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EqualsReturnsFalseInsuranceCompany()
        {
            var company1 = new InsuranceСompany("Type1", 100, 5000000);
            var company2 = new InsuranceСompany("Type2", 200, 3000000);

            bool result = company1.Equals(company2);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void EqualsNullObjIns()
        {
            var ins1 = new InsuranceСompany("Type1", 100, 500000);
            var ins2 = new InsuranceСompany();
            bool result = ins1.Equals(ins2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ToStringInsuranceСompany()
        {
            var company = new InsuranceСompany("Type1", 100, 5000000);

            string result = company.ToString();

            Assert.AreEqual("Страховая компания Тип: Type1: Количество сотрудников: 100: Страховой фонд : 5000000", result);
        }

        [TestMethod]
        public void GetHashCodeReturnsSameHashCodeInsuranceCompany()
        {
            var org1 = new InsuranceСompany { Type = "Type1", EmployeeCount = 100, InsuranceFund = 5000000 };
            var org2 = new InsuranceСompany { Type = "Type1", EmployeeCount = 100, InsuranceFund = 5000000 };

            int hash1 = org1.GetHashCode();
            int hash2 = org2.GetHashCode();

            Assert.AreEqual(hash1, hash2, "Hash codes should be equal for equal objects.");
        }

        // тест Factory

        [TestMethod]
        public void DepartmentCountThrowsException()
        {
            var factory = new Factory();

            var exception = Assert.ThrowsException<Exception>(() => factory.DepartmentCount = -1);
            Assert.AreEqual("Ошибка, значение не может быть отрицательным", exception.Message);
        }
        [TestMethod]
        public void DepartmentCountRight()
        {
            var factory = new Factory("Type1", 500, 10);
            Assert.AreEqual(10, factory.DepartmentCount);
        }

        [TestMethod]
        public void EqualsReturnsTrueFactory()
        {
            var factory1 = new Factory("Type1", 100, 5);
            var factory2 = new Factory("Type1", 100, 5);

            bool result = factory1.Equals(factory2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EqualsReturnsFalseFactory()
        {
            var factory1 = new Factory("Type1", 100, 5);
            var factory2 = new Factory("Type2", 200, 10);

            bool result = factory1.Equals(factory2);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void EqualsNullObjFactory()
        {
            var fac1 = new Factory("Type1", 100, 5);
            var fac2 = new Factory();
            bool result = fac1.Equals(fac2);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void GetHashCodeReturnsSameHashCodeFactory()
        {
            var org1 = new Factory { Type = "Type1", EmployeeCount = 100, DepartmentCount = 10 };
            var org2 = new Factory { Type = "Type1", EmployeeCount = 100, DepartmentCount = 10 };

            int hash1 = org1.GetHashCode();
            int hash2 = org2.GetHashCode();

            Assert.AreEqual(hash1, hash2, "Hash codes should be equal for equal objects.");
        }

        // тест ShipBuildingCompany
        [TestMethod]
        public void ShipCountThrowsException()
        {
            var company = new ShipbuildingСompany();

            var exception = Assert.ThrowsException<Exception>(() => company.ShipCount = -1);
            Assert.AreEqual("Ошибка, значение не может быть отрицательным!", exception.Message);
        }
        [TestMethod]
        public void ShipCountRight()
        {
            var shipCount = new ShipbuildingСompany("Type1", 100, 10, 25);
            Assert.AreEqual(25, shipCount.ShipCount);
        }
        [TestMethod]
        public void EqualsReturnsTrueShipBuildingCompany()
        {
            var company1 = new ShipbuildingСompany("Type1", 100, 5, 10);
            var company2 = new ShipbuildingСompany("Type1", 100, 5, 10);

            bool result = company1.Equals(company2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EqualsReturnsFalseShipBuildingCompany()
        {
            var company1 = new ShipbuildingСompany("Type1", 100, 5, 10);
            var company2 = new ShipbuildingСompany("Type2", 200, 10, 20);

            bool result = company1.Equals(company2);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void EqualsNullObjShb()
        {
            var ship1 = new ShipbuildingСompany("Type1", 100, 5, 30);
            var ship2 = new ShipbuildingСompany();
            bool result = ship1.Equals(ship2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetHashCodeReturnsSameHashCodeShipBuildingCompany()
        {
            var org1 = new ShipbuildingСompany { Type = "Type1", EmployeeCount = 100, DepartmentCount = 10, ShipCount = 35 };
            var org2 = new ShipbuildingСompany { Type = "Type1", EmployeeCount = 100, DepartmentCount = 10, ShipCount = 35 };

            int hash1 = org1.GetHashCode();
            int hash2 = org2.GetHashCode();

            Assert.AreEqual(hash1, hash2, "Hash codes should be equal for equal objects.");
        }

        // тест Library
        [TestMethod]
        public void TextbookCountThrowsExceptionLibrary()
        {
            var library = new Library();

            var exception = Assert.ThrowsException<Exception>(() => library.TextbookCount = -1);
            Assert.AreEqual("Ошибка, значение не может быть отрицательным!", exception.Message);
        }
        
        [TestMethod]
        public void EqualsReturnsTrueLibrary()
        {
            var library1 = new Library("Type1", 50, 100);
            var library2 = new Library("Type1", 50, 100);

            bool result = library1.Equals(library2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EqualsReturnsFalseLibrary()
        {
            var library1 = new Library("Type1", 50, 100);
            var library2 = new Library("Type2", 60, 200);

            bool result = library1.Equals(library2);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void EqualsNullObjLib()
        {
            var lib1 = new Library("Type1", 100, 500);
            var lib2 = new Library();
            bool result = lib1.Equals(lib2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetHashCodeReturnsSameHashCodeLibrary()
        {
            var org1 = new Library { Type = "Type1", EmployeeCount = 100, TextbookCount = 10 };
            var org2 = new Library { Type = "Type1", EmployeeCount = 100, TextbookCount = 10 };

            int hash1 = org1.GetHashCode();
            int hash2 = org2.GetHashCode();

            Assert.AreEqual(hash1, hash2, "Hash codes should be equal for equal objects.");
        }

        // тест класса Init

        [TestMethod]
        public void DefaultConstructor()
        {
            var animal = new Animal();

            string expectedName = "NULL";
            int expectedWeight = 0;

            Assert.AreEqual(expectedName, animal.Name);
            Assert.AreEqual(expectedWeight, animal.Weight);
        }

        [TestMethod]
        public void ParameterizedConstructor()
        {
            string name = "Лев";
            int weight = 50;

            var animal = new Animal(name, weight);

            Assert.AreEqual(name, animal.Name);
            Assert.AreEqual(weight, animal.Weight);
        }

        // тесты Compare

        [TestMethod]
        public void Compare_ShouldReturnNegativeWhenFirstTypeIsLessThanSecond()
        {
            Organization[] org = new Organization[3];
            org[0] = new Organization { Type = "B" };
            org[1] = new Organization { Type = "C" };
            org[2] = new Organization { Type = "A" };

            Array.Sort(org, new SortByType());

            Assert.AreEqual("A", org[0].Type);
            Assert.AreEqual("B", org[1].Type);
            Assert.AreEqual("C", org[2].Type);
        }

        [TestMethod]
        public void Compare_SortByEmployeeCount()
        {
            Organization[] org = new Organization[3];
            org[0] = new Organization { EmployeeCount = 932 };
            org[1] = new Organization { EmployeeCount = 241 };
            org[2] = new Organization { EmployeeCount = 653 };

            Array.Sort(org, new SortByEmployeeCount());

            Assert.AreEqual(241, org[0].EmployeeCount);
            Assert.AreEqual(653, org[1].EmployeeCount);
            Assert.AreEqual(932, org[2].EmployeeCount);
        }

        [TestMethod]
        public void Compare_BinarySearchByEmployeeCount()
        {
            Organization[] org = new Organization[3];
            org[0] = new Organization { EmployeeCount = 932 };
            org[1] = new Organization { EmployeeCount = 241 };
            org[2] = new Organization { EmployeeCount = 653 };
            Organization organization = new Organization() { EmployeeCount = org[1].EmployeeCount };

            Array.BinarySearch(org, organization, new BinarySearchByEmployeeCount());
        }

        // тесты Program
        [TestMethod]
        public void TestSumShips()
        {
            Organization[] org = new Organization[3];
            org[0] = new ShipbuildingСompany { ShipCount = 321 };
            org[1] = new ShipbuildingСompany { ShipCount = 129 };
            org[2] = new ShipbuildingСompany { ShipCount = 32 };
            int sum = ((ShipbuildingСompany)org[0]).ShipCount + ((ShipbuildingСompany)org[1]).ShipCount + ((ShipbuildingСompany)org[2]).ShipCount;

            Assert.AreEqual(sum, Program.SumShips(org));
        }
    }
}


