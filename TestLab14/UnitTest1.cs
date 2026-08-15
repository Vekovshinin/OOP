using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab14;
using OrganizationLib;
using lab12;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestLab14
{
    [TestClass]
    public class QueryTests
    {
        private GenericCollection collection;
        private Tree<Organization> tree;

        [TestInitialize]
        public void Initialize()
        {
            collection = new GenericCollection(5, 10);
            tree = new Tree<Organization>();

            for (int i = 0; i < 10; i++)
            {
                Organization org = new Organization();
                org.RandInit();
                tree.Add(org);
            }
        }

        [TestMethod]
        public void TestWhereLINQ()
        {
            int employeeCount = 50;
            var result = Query.WhereLINQ(collection.sortedDictionary, employeeCount);

            foreach(var org in result)
            {
                Assert.IsTrue(org.EmployeeCount > employeeCount);
            }
        }

        [TestMethod]
        public void TestWhereExtension()
        {
            int employeeCount = 50;
            var result = collection.sortedDictionary.WhereExtension(org => org.EmployeeCount > employeeCount);

            foreach (var org in result)
            {
                Assert.IsTrue(org.EmployeeCount > employeeCount);
            }
        }

        [TestMethod]
        public void TestCountLINQ()
        {
            int employeeCount = 50;
            int result = Query.CountLINQ(collection.sortedDictionary, employeeCount);

            Assert.IsTrue(result >= 0);
        }

        [TestMethod]
        public void TestCountExtension()
        {
            int employeeCount = 50;
            int result = collection.sortedDictionary.CountExtension(org => org.EmployeeCount <= employeeCount);

            Assert.IsTrue(result >= 0);
        }

        [TestMethod]
        public void TestUnionLINQ()
        {
            string orgType = "Type1";
            var result = Query.UnionLINQ(collection.sortedDictionary, collection.sortedDictionary, orgType);

            foreach(var org in result)
            {
                Assert.IsTrue(org.Type.Contains(orgType));
            }
        }

        [TestMethod]
        public void TestUnionExtension()
        {
            string orgType = "Type1";
            var result = collection.sortedDictionary.UnionExtension(collection.sortedDictionary, orgType);

            foreach (var org in result)
            {
                Assert.IsTrue(org.Type.Contains(orgType));
            }
        }

        [TestMethod]
        public void TestAverageLINQ()
        {
            int result = Query.AverageLINQ(collection.sortedDictionary);

            Assert.IsTrue(result >= 0);
        }

        [TestMethod]
        public void TestAverageExtension()
        {
            int result = collection.sortedDictionary.AverageExtension();

            Assert.IsTrue(result >= 0);
        }

        [TestMethod]
        public void TestGroupLINQ()
        {
            var queue1 = new Queue<Organization>();
            queue1.Enqueue(new Organization { Type = "Type1", EmployeeCount = 10 });
            queue1.Enqueue(new Organization { Type = "Type2", EmployeeCount = 20 });

            var queue2 = new Queue<Organization>();
            queue2.Enqueue(new Organization { Type = "Type1", EmployeeCount = 30 });
            queue2.Enqueue(new Organization { Type = "Type3", EmployeeCount = 40 });

            var sortedDictionary = new SortedDictionary<int, Queue<Organization>>
                {
                    { 1, queue1 },
                    { 2, queue2 }
                };

            var groups = Query.GroupLINQ(sortedDictionary);

            Assert.AreEqual(3, groups.Count()); 

            foreach (var group in groups)
            {
                if (group.Key == "Type1")
                {
                    Assert.AreEqual(2, group.Count()); 
                }
                else if (group.Key == "Type2")
                {
                    Assert.AreEqual(1, group.Count()); 
                }
                else if (group.Key == "Type3")
                {
                    Assert.AreEqual(1, group.Count()); 
                }
                else
                {
                    Assert.Fail("Неожиданный тип группы: " + group.Key);
                }
            }
        }

        [TestMethod]
        public void TestGroupExtension()
        {
            var queue1 = new Queue<Organization>();
            queue1.Enqueue(new Organization { Type = "Type1", EmployeeCount = 10 });
            queue1.Enqueue(new Organization { Type = "Type2", EmployeeCount = 20 });

            var queue2 = new Queue<Organization>();
            queue2.Enqueue(new Organization { Type = "Type1", EmployeeCount = 30 });
            queue2.Enqueue(new Organization { Type = "Type3", EmployeeCount = 40 });

            var sortedDictionary = new SortedDictionary<int, Queue<Organization>>
                {
                    { 1, queue1 },
                    { 2, queue2 }
                };

            var groups = sortedDictionary.GroupExtension();

            Assert.AreEqual(3, groups.Count()); 

            foreach (var group in groups)
            {
                if (group.Key == "Type1")
                {
                    Assert.AreEqual(2, group.Count());
                }
                else if (group.Key == "Type2")
                {
                    Assert.AreEqual(1, group.Count());
                }
                else if (group.Key == "Type3")
                {
                    Assert.AreEqual(1, group.Count());
                }
                else
                {
                    Assert.Fail("Неожиданный тип группы: " + group.Key);
                }
            }
        }

        [TestMethod]
        public void TestTreeSelectLINQ()
        {
            string type = "Type1";
            var result = Query.TreeSelectLINQ(tree, type);

            foreach (var org in result)
            {
                Assert.IsTrue(org.Type.Contains(type));
            }
        }

        [TestMethod]
        public void TestTreeSelectExtension()
        {
            string type = "Type1";
            var result = tree.TreeSelectExtension(org => org.Type.Contains(type));

            foreach (var org in result)
            {
                Assert.IsTrue(org.Type.Contains(type));
            }
        }

        [TestMethod]
        public void TestTreeAgregateLINQ()
        {
            int result = tree.TreeAgregateLINQ();

            Assert.IsTrue(result >= 0);
        }

        [TestMethod]
        public void TestTreeAgregateExtension()
        {
            var result = tree.TreeAgregateExtension(org => org.EmployeeCount);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestTreeOrderByDescendingLINQ()
        {
            var result = Query.TreeOrderByDescendingLINQ(tree);

            Organization previous = null;
            foreach (var org in result)
            {
                if (previous != null)
                {
                    Assert.IsTrue(org.EmployeeCount <= previous.EmployeeCount);
                }
                previous = org;
            }
        }

        [TestMethod]
        public void TestTreeOrderByDescendingExtension()
        {
            var result = tree.TreeOrderByDescendingExtension(org => org.EmployeeCount);

            Organization previous = null;
            foreach (var org in result)
            {
                if (previous != null)
                {
                    Assert.IsTrue(org.EmployeeCount <= previous.EmployeeCount);
                }
                previous = org;
            }
        }
    }
}
