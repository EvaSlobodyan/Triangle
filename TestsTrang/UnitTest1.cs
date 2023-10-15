using Trangle;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using static Trangle.Triangle;

namespace TestsTrang
{
    public class Tests
    {
        
        [Test]
        public void GetTriangleInfo_EquilateralTriangle_ReturnsCorrectTriangleTypeAndVertices()
        {
            // Arrange
            string sideA = "5";
            string sideB = "5";
            string sideC = "5";

            // Act
            var result = Triangle.GetTriangleInfo(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("равнобедренный", result.Item1);
            Assert.AreEqual(new List<(int, int)> { (0, 0), (5, 0), (2, 4) }, result.Item2);
        }
               

        [Test]
        public void GetTriangleInfo_NotATriangle_ReturnsCorrectTriangleTypeAndVertices()
        {
            // Arrange
            string sideA = "1";
            string sideB = "2";
            string sideC = "3";

            // Act
            var result = Triangle.GetTriangleInfo(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("не треугольник", result.Item1);
            Assert.AreEqual(new List<(int, int)> { (-4, -1), (-1, -1), (-1, -1) }, result.Item2);
        }

       
        [Test]
        public void GetTriangleInfo_InvalidSideLengthFormat_ReturnsEmptyTriangleTypeAndVertices()
        {
            // Arrange
            string sideA = "1.5.6";
            string sideB = "2";
            string sideC = "3";

            // Act
            var result = Triangle.GetTriangleInfo(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("", result.Item1);
            Assert.AreEqual(new List<(int, int)> { (-2, -2), (-2, -2), (-4, -2) }, result.Item2);
        }


        [Test]
        public void GetTriangleInfo_InvalidData()
        {
            // Arrange
            string sideA = "2.0";
            string sideB = "1.0";
            string sideC = "7.0";

            // Act
            var result = Triangle.GetTriangleInfo(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
        }

        [Test]
        public void GetTriangleInfo_NegativeSides()
        {
            // Arrange
            string sideA = "-3.0";
            string sideB = "4.5";
            string sideC = "5.5";

            // Act
            var result = Triangle.GetTriangleInfo(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
        }


        [Test]
        public void GetTriangleInfo_InvalidEmailLogin()
        {
            // Arrange
            string sideA = "invalid-email";
            string sideB = "5.0";
            string sideC = "6.0";

            // Act
            var result = Triangle.GetTriangleInfo(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
        }

        [Test]
        public void GetTriangleInfo_InvalidPhoneLogin()
        {
            // Arrange
            string sideA = "+1-123-456-789";
            string sideB = "5.0";
            string sideC = "6.0";

            // Act
            var result = Triangle.GetTriangleInfo(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
        }


        [Test]
        public void GetTriangleInfo_InvalidTriangle_ReturnsCorrectResult()
        {
            // Arrange
            string sideA = "1";
            string sideB = "2";
            string sideC = "10";

            // Act
            var result = Triangle.GetTriangleInfo(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("не треугольник", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((-4, -1), result.Item2[0]);
            Assert.AreEqual((-1, -1), result.Item2[1]);
            Assert.AreEqual((-1, -1), result.Item2[2]);
        }

        [Test]
        //тест на нулевую длину сторон
        public void GetTriangleInfo_NegativeSides_ReturnsCorrectResult()
        {
            // Arrange
            string sideA = "-3";
            string sideB = "4";
            string sideC = "5";

            // Act
            var result = Triangle.GetTriangleInfo(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual("", result.Item1);
            Assert.AreEqual(3, result.Item2.Count);
            Assert.AreEqual((-2, -2), result.Item2[0]);
            Assert.AreEqual((-2, -3), result.Item2[1]);
            Assert.AreEqual((-2, -2), result.Item2[2]);
        }
        [Test]
        public void GetAverage_EmptyList_ReturnsZero()
        {
            // Arrange
            List<int> numbers = new List<int>();

            // Act
            double average = Calculator.GetAverage(numbers);

            // Assert
            Assert.AreEqual(0, average);
        }
        [Test]
        public void GetAverage_SingleElementList_ReturnsElementValue()
        {
            // Arrange
            List<int> numbers = new List<int> { 5 };

            // Act
            double average = Calculator.GetAverage(numbers);

            // Assert
            Assert.AreEqual(5, average);
        }
        [Test]
        public void GetAverage_PositiveIntegerList_ReturnsCorrectAverage()
        {
            // Arrange
            List<int> numbers = new List<int> { 2, 4, 6, 8, 10 };

            // Act
            double average = Calculator.GetAverage(numbers);

            // Assert
            Assert.AreEqual(6, average);
        }
        [Test]
        public void GetAverage_NegativeIntegerList_ReturnsCorrectAverage()
        {
            // Arrange
            List<int> numbers = new List<int> { -3, -5, -7, -9 };

            // Act
            double average = Calculator.GetAverage(numbers);

            // Assert
            Assert.AreEqual(-6, average);
        }
        //[Test]
        //public void GetAverage_DoubleList_ReturnsCorrectAverage()
        //{
        //    // Arrange
        //    List<double> numbers = new List<double> { 1.5, 2.5, 3.5, 4.5 };

        //    // Act
        //    double average = Calculator.GetAverage(numbers);

        //    // Assert
        //    Assert.AreEqual(3.0, average);
        //}

        [Test]
        public void GetAverage_MixedNumberList_ReturnsCorrectAverage()
        {
            // Arrange
            List<int> numbers = new List<int> { -2, 4, -6, 8, -10 };

            // Act
            double average = Calculator.GetAverage(numbers);

            // Assert
            Assert.AreEqual(-1.2, average);
        }
       
        [Test]
        public void GetAverage_SingleNegativeNumberList_ReturnsCorrectAverage()
        {
            // Arrange
            List<int> numbers = new List<int> { -5 };

            // Act
            double average = Calculator.GetAverage(numbers);

            // Assert
            Assert.AreEqual(-5, average);
        }
      
    }
}