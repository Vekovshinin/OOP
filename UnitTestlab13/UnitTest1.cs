using Lab13;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrganizationLib;
using System;
using System.Collections;
using System.Globalization;

namespace UnitTestlab13
{
    [TestClass]
    public class CollectionHandlerEventArgsTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            string testCollectionName = "TestName";
            string testChangeType = "Add";
            Organization testAffectedObject = new Organization { Type = "Госудерственная", EmployeeCount = 1 };
            CollectionHandlerEventArgs eventArgs = new CollectionHandlerEventArgs(testCollectionName, testChangeType, testAffectedObject);
            Assert.AreEqual(testCollectionName, eventArgs.CollectionName);
            Assert.AreEqual(testChangeType, eventArgs.ChangeType);
            Assert.AreEqual(testAffectedObject, eventArgs.AffectedObject);
        }

        [TestMethod]
        public void TestToString()
        {
            string testCollectionName = "TestName";
            string testChangeType = "Add";
            Organization testAffectedObject = new Organization { Type = "Госудерственная", EmployeeCount = 1 };
            var eventArgs = new CollectionHandlerEventArgs(testCollectionName, testChangeType, testAffectedObject);
            string res = eventArgs.ToString();
            string expectedString = $"Имя коллекции: {testCollectionName}, Тип изменения: {testChangeType}, Затронутый объект: {testAffectedObject}";
            Assert.AreEqual(expectedString, res, "Метод ToString() возвращает неправильную строку.");
        }
    }
    [TestClass]
    public class NewTreeTest
    {
        private NewTree newTree;
        [TestInitialize]
        public void Setup()
        {
            newTree = new NewTree { CollectionName = "TestCollection" };
            newTree.CollectionName = "test";
            Organization org1 = new Organization();
            org1.RandInit();
            Organization org2 = new Organization();
            org2.RandInit();
            Organization org3 = new Organization();
            org3.RandInit();
            newTree.Add(org1);
            newTree.Add(org2);
            newTree.Add(org3);
        }
        [TestMethod]
        public void TestIndexator()
        {
            Organization newOrg = new Organization("null", 0);
            newTree[0] = newOrg;
            Assert.AreEqual(newOrg, newTree[0]);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIndexator2()
        {
            var result = newTree[-1];
        }
        [TestMethod]
        public void TestAddEvent()
        {
            Organization newOrg = new Organization("null", 1);
            newTree.Add(newOrg);
            bool eventTrig = false;
            newTree.CollectionCountChanged += (sender, args) =>
            {
                eventTrig = true;
                Assert.AreEqual("TestCollection", args.CollectionName);
                Assert.AreEqual("Изменение элемента", args.ChangeType);
                Assert.AreEqual(newOrg.ToString(), args.AffectedObject);
            };
        }
        [TestMethod]
        public void TestRemoveEvent()
        {
            Organization newOrg = new Organization("null", 1);
            newTree.Add(newOrg);
            newTree.Remove(newOrg);
            bool removeTrig = false;
            newTree.CollectionCountChanged += (sender, args) =>
            {
                removeTrig = true;
                Assert.AreEqual("TestCollection", args.CollectionName);
                Assert.AreEqual("Удаление элемента", args.ChangeType);
                Assert.AreEqual(newOrg.ToString(), args.AffectedObject);
            };
        }
        [TestMethod]
        public void TestIndexatorEvent()
        {
            Organization newOrg = new Organization("null", 1);
            newTree[0] = newOrg;
            bool eventTrig = false;
            newTree.CollectionReferenceChanged += (sender, args) =>
            {
                eventTrig = true;
                Assert.AreEqual("TestCollection", args.CollectionName);
                Assert.AreEqual("Изменение элемента", args.ChangeType);
                Assert.AreEqual(newOrg.ToString(), args.AffectedObject);
            };
        }
    }
    [TestClass]
    public class JournalTests
    {
        [TestMethod]
        public void JournalEntry_Constructor()
        {
            string collectionName = "TestCollection";
            string changeType = "Insert";
            string data = "TestData";

            var entry = new JournalEntry(collectionName, changeType, data);

            Assert.AreEqual(collectionName, entry.CollectionName);
            Assert.AreEqual(changeType, entry.ChangeType);
            Assert.AreEqual(data, entry.Data);
        }

        [TestMethod]
        public void JournalEntry_ToString()
        {
            var entry = new JournalEntry("TestCollection", "Insert", "TestData");

            string result = entry.ToString();

            Assert.AreEqual("Коллекция: TestCollection, Тип изменения: Insert, Объект: TestData", result);
        }

        [TestMethod]
        public void Journal_AddEntry()
        {
            var journal = new Journal();
            var entry = new JournalEntry("TestCollection", "Insert", "TestData");

            journal.AddEntry(entry);

            Assert.AreEqual("Записи в журнале:\nКоллекция: TestCollection, Тип изменения: Insert, Объект: TestData\n", journal.ToString());
        }

        [TestMethod]
        public void Journal_ToString()
        {
            var journal = new Journal();
            var entry1 = new JournalEntry("Collection1", "Insert", "Data1");
            var entry2 = new JournalEntry("Collection2", "Update", "Data2");
            journal.AddEntry(entry1);
            journal.AddEntry(entry2);

            string result = journal.ToString();

            string expected = "Записи в журнале:\n" +
                              "Коллекция: Collection1, Тип изменения: Insert, Объект: Data1\n" +
                              "Коллекция: Collection2, Тип изменения: Update, Объект: Data2\n";

            Assert.AreEqual(expected, result);
        }
    }
}
