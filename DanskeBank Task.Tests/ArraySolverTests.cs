using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Mvc.Html;
using CodingTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DanskeBank_Task.Tests
{
    [TestFixture]
    public class ArraySolverTests
    {
        [Test]
        public void Solve_WhenGivenArrayIsEmpty_ReturnFalse()
        {
            // Arrange
            int[] numbers = new int[] { };
            bool result;
            List<int> path = new List<int>();

            // Act
            result = ArraySolver.Solve(numbers, out path);

            // Assert
            Assert.AreEqual(result, false);
        }

        [Test]
        [TestCase(new int[] { 3, 2, 2, 1, 5, 4, 6 })]
        [TestCase(new int[] { 1, 2, 0, 3, 0, 2, 0 })]
        [TestCase(new int[] { 2, 3, 0, 3, 4 })]
        [TestCase(new int[] { 4, 2, 4, 2, 6, 2, 5, 7})]
        public void Solve_WhenGivenArrayIsWinnable_ReturnTrue(int[] input)
        {
            // Arrange
            int[] numbers = input;
            bool result;
            List<int> path = new List<int>();

            // Act
            result = ArraySolver.Solve(numbers, out path);

            // Assert
            Assert.AreEqual(result, true);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 0, 1, 0, 2, 0 })]
        [TestCase(new int[] { 1, 2, 0, -1, 0, 2, 0 })]
        [TestCase(new int[] { 1, 2, 1, -1, 0, 2, 0 })]
        [TestCase(new int[] { 4, 0, 1, -3, -1, 0, 1 })]
        public void Solve_WhenGivenArrayIsNotWinnable_ReturnFalse(int[] input)
        {
            // Arrange
            int[] numbers = input;
            bool result;
            List<int> path = new List<int>();

            // Act
            result = ArraySolver.Solve(numbers, out path);

            // Assert
            Assert.AreEqual(result, false);
        }
    }
}
