using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLab9;
using System;
using Laba9;

namespace TestLab9
{
    [TestClass]
    public class TestLab9
    {
        [TestMethod]
        public void Constructor_IncrementsCount()
        {
            int initialCount = Triangle.Count;

            var triangle = new Triangle(3, 4, 5);

            Assert.AreEqual(initialCount + 1, Triangle.Count);
        }

        [TestMethod]
        public void A_Property_Get_Set()
        {
            var triangle = new Triangle(3, 4, 5);

            triangle.A = 6;

            Assert.AreEqual(6, triangle.A);
        }

        [TestMethod]
        public void B_Property_Get_Set()
        {
            var triangle = new Triangle(3, 4, 5);

            triangle.B = 7;

            Assert.AreEqual(7, triangle.B);
        }

        [TestMethod]
        public void C_Property_Get_Set()
        {
            var triangle = new Triangle(3, 4, 5);

            triangle.C = 8;

            Assert.AreEqual(8, triangle.C);
        }

        [TestMethod]
        public void Properties_SetAndGetCorrectly()
        {
            var triangle = new Triangle(3, 4, 5);

            triangle.A = 6;
            triangle.B = 7;
            triangle.C = 8;

            Assert.AreEqual(6, triangle.A);
            Assert.AreEqual(7, triangle.B);
            Assert.AreEqual(8, triangle.C);
        }

        [TestMethod]
        public void Constructor_CopyConstructor_IncrementsCount()
        {
            var originalTriangle = new Triangle(3, 4, 5);
            int initialCount = Triangle.Count;

            var copiedTriangle = new Triangle(originalTriangle);

            Assert.AreEqual(initialCount + 1, Triangle.Count);
            Assert.AreEqual(originalTriangle.A, copiedTriangle.A);
            Assert.AreEqual(originalTriangle.B, copiedTriangle.B);
            Assert.AreEqual(originalTriangle.C, copiedTriangle.C);
        }

        [TestMethod]
        public void Exist_ReturnsTrue_WhenTriangleExists()
        {
            var triangle = new Triangle(3, 4, 5);

            bool exists = triangle.Exist();

            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void Exist_ReturnsFalse_WhenTriangleDoesNotExist()
        {
            var triangle = new Triangle();

            bool exists = triangle.Exist();

            Assert.IsFalse(exists);
        }

        [TestMethod]
        public void CalculateSquare_ReturnsArea_WhenTriangleExists()
        {
            var triangle = new Triangle(3, 4, 5);

            double square = triangle.CalculateSquare();

            Assert.AreEqual(6, square, 0.001);
        }

        [TestMethod]
        public void CalculateSquare_ReturnsNegativeOne_WhenTriangleDoesNotExist()
        {
            var triangle = new Triangle(1, 2, 3);

            double square = triangle.CalculateSquare();

            Assert.AreEqual(-1, square);
        }

        [TestMethod]
        public void IncrementOperator_IncreasesSides()
        {
            var triangle = new Triangle(3, 4, 5);

            triangle++;

            Assert.AreEqual(4, triangle.A);
            Assert.AreEqual(5, triangle.B);
            Assert.AreEqual(6, triangle.C);
        }

        [TestMethod]
        public void DecrementOperator_DecreasesSides()
        {
            var triangle = new Triangle(3, 4, 5);

            triangle--;

            Assert.AreEqual(2, triangle.A);
            Assert.AreEqual(3, triangle.B);
            Assert.AreEqual(4, triangle.C);
        }

        [TestMethod]
        public void ExplicitOperator_CastsToDouble_ReturnsArea()
        {
            var triangle = new Triangle(3, 4, 5);

            double square = (double)triangle;

            Assert.AreEqual(6, square, 0.001);
        }

        [TestMethod]
        public void ImplicitOperator_CastsToBool_ReturnsExistence()
        {
            var triangle = new Triangle(3, 4, 5);

            bool exists = triangle;

            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void LessThanOrEqualOperator_ComparingAreas()
        {
            var triangle1 = new Triangle(3, 4, 5); // Square = 6
            var triangle2 = new Triangle(6, 8, 10); // Square = 24

            Assert.IsTrue(triangle1 <= triangle2);
        }

        [TestMethod]
        public void GreaterThanOrEqualOperator_ComparingAreas()
        {
            var triangle1 = new Triangle(6, 8, 10); // Square = 24
            var triangle2 = new Triangle(3, 4, 5); // Square = 6

            Assert.IsTrue(triangle1 >= triangle2);
        }

        private TriangleArray triangleArray;

        [TestMethod]
        public void Indexer_Get_ReturnsCorrectTriangle()
        {
            triangleArray = new TriangleArray(3);

            var triangle = triangleArray[0];

            Assert.IsNotNull(triangle);
        }

        [TestMethod]
        public void Indexer_Set_UpdatesTriangle()
        {
            triangleArray = new TriangleArray(3);
            var newTriangle = new Triangle(6, 8, 10);

            triangleArray[0] = newTriangle;

            Assert.AreEqual(newTriangle, triangleArray[0]);
        }

        [TestMethod]
        public void Indexer_Get_OutOfRange_ThrowsException()
        {
            triangleArray = new TriangleArray(3);

            Assert.ThrowsException<IndexOutOfRangeException>(() => { var triangle = triangleArray[5]; });
        }

        [TestMethod]
        public void FindIndexWithMinSquare_ReturnsCorrectIndex()
        {
            triangleArray = new TriangleArray(3);
            triangleArray[0] = new Triangle(3, 4, 5); // Square = 6
            triangleArray[1] = new Triangle(6, 8, 10); // Square = 24
            triangleArray[2] = new Triangle(1, 1, 1); // Square = 0.433

            int minIndex = triangleArray.FindIndexWithMinSquare();

            Assert.AreEqual(3, minIndex); // Индекс 3 соответствует треугольнику с минимальной площадью
        }

        [TestMethod]
        public void FindIndexWithMinSquare_EmptyArray_ThrowsException()
        {
            var triangleArray = new TriangleArray();

            Assert.ThrowsException<InvalidOperationException>(() => triangleArray.FindIndexWithMinSquare());
        }
    }
}
