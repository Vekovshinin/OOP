using lab12;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrganizationLib;
using System;
using System.Collections.Generic;
using System.IO;

namespace UnitTestLab12
{
    [TestClass]
    public class PointTests
    {
        [TestMethod]
        public void TestDefaultConstructor()
        {
            var point = new Point<int>();

            var data = point.Data;
            var left = point.Left;
            var right = point.Right;

            Assert.AreEqual(default(int), data); 
            Assert.IsNull(left); 
            Assert.IsNull(right); 
        }

        [TestMethod]
        public void TestParameterizedConstructor()
        {
            int expectedData = 5;
            var point = new Point<int>(expectedData);

            var data = point.Data;

            Assert.AreEqual(expectedData, data); 
            Assert.IsNull(point.Left); 
            Assert.IsNull(point.Right); 
        }

        [TestMethod]
        public void TestSettingProperties()
        {
            var point = new Point<int>(10);
            var leftPoint = new Point<int>(5);
            var rightPoint = new Point<int>(15);

            point.Left = leftPoint;
            point.Right = rightPoint;

            Assert.AreEqual(leftPoint, point.Left); 
            Assert.AreEqual(rightPoint, point.Right); 
        }
    }
    [TestClass]
    public class TreeTest
    {
        public class MyData : IComparable<MyData>, ICloneable
        {
            public int Value { get; set; }

            public MyData(int value)
            {
                Value = value;
            }

            public int CompareTo(MyData other)
            {
                return Value.CompareTo(other.Value);
            }

            public object Clone()
            {
                return new MyData(Value);
            }

            public override string ToString()
            {
                return Value.ToString();
            }
        }
        private Tree<MyData> tree;

        [TestInitialize]
        public void Setup()
        {
            tree = new Tree<MyData>();
            tree.AddPoint(new MyData(5));
            tree.AddPoint(new MyData(3));
            tree.AddPoint(new MyData(7));
            tree.AddPoint(new MyData(2));
            tree.AddPoint(new MyData(4));
            tree.AddPoint(new MyData(6));
            tree.AddPoint(new MyData(8));
            tree.AddPoint(new MyData(1));
        }
        [TestMethod]
        public void TestIndexator()
        {
            tree[0] = new MyData(0);
            Assert.AreEqual(0, tree[0].Value);
        }

        [TestMethod]
        public void TestIndexator1()
        {
            tree[7] = new MyData(15);
            Assert.AreEqual(15, tree[7].Value);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIndexator2()
        {
            var value = tree[-1];
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIndexator3()
        {
            tree[-1] = new MyData(0);
        }
        [TestMethod]
        public void TestAddPoint()
        {
            Assert.AreEqual(8, tree.Count); 
        }
        [TestMethod]
        public void TestClone()
        {
            Tree<MyData> cloneTree = new Tree<MyData>(tree);
            Assert.IsNotNull(cloneTree);
        }

        [TestMethod]
        public void TestShallowCopy()
        {
            Tree<MyData> shallowCopy = tree.ShallowCopy();
            Assert.AreNotSame(tree, shallowCopy);
            Assert.AreEqual(tree.Count, shallowCopy.Count); 
        }

        [TestMethod]
        public void TestDeleteTree()
        {
            tree.DeleteTree();
            Assert.AreEqual(0, tree.Count); 
            Assert.IsNull(tree.Search(new MyData(5))); 
        }

        [TestMethod]
        public void TestAdd()
        {
            tree.Add(new MyData(9));
            Assert.AreEqual(9, tree.Count); 
            Assert.IsNotNull(tree.Search(new MyData(9))); 
        }

        [TestMethod]
        public void TestClear()
        {
            tree.Clear();
            Assert.AreEqual(0, tree.Count); 
        }

        [TestMethod]
        public void TestContains()
        {
            Assert.IsTrue(tree.Contains(new MyData(5))); 
            Assert.IsFalse(tree.Contains(new MyData(10)));
        }

        [TestMethod]
        public void TestGetEnumerator()
        {
            List<MyData> items = new List<MyData>();
            foreach (var item in tree)
            {
                items.Add(item);
            }

            List<MyData> expectedList = new List<MyData>(tree);
            CollectionAssert.AreEqual(expectedList, items);
        }

        [TestMethod]
        public void TestRemoveWithTwoChild()
        {
            bool removed = tree.Remove(new MyData(3));
            Assert.IsTrue(removed);
            Assert.AreEqual(6, tree.Count); 
            Assert.IsFalse(tree.Contains(new MyData(3)));
        }
        [TestMethod]
        public void TestRemoveWithoutChild()
        {
            bool removed = tree.Remove(new MyData(2));
            Assert.IsTrue(removed);
            Assert.AreEqual(7, tree.Count);
            Assert.IsFalse(tree.Contains(new MyData(2)));
        }
        [TestMethod]
        public void TestRemoveWithLeftChild()
        {
            bool removed = tree.Remove(new MyData(1));
            Assert.IsTrue(removed);
            Assert.AreEqual(7, tree.Count);
            Assert.IsFalse(tree.Contains(new MyData(1)));
        }
        [TestMethod]
        public void TestRemoveWithRightChild()
        {
            tree.AddPoint(new MyData(9));
            bool removed = tree.Remove(new MyData(9));
            Assert.IsTrue(removed);
            Assert.AreEqual(8, tree.Count);
            Assert.IsFalse(tree.Contains(new MyData(9)));
        }
    }
}

