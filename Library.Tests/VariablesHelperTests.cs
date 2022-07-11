using NUnit.Framework;
using System;

namespace Library.Tests
{
    public class Tests
    {
        [TestCase(5, 10, 10)]
        [TestCase(10, 10, 10)]
        [TestCase(10, 5, 10)]
        [TestCase(-5, -10, -5)]
        [TestCase(0, 0, 0)]
        public void Max_WhenAAndBPassed_ShouldFindMax
            (int a, int b, int expected)
        {
            //Act
            int actual = VariablesHelper.Max(a, b);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2, 1)]
        [TestCase(8, -3, 2)]
        [TestCase(-10, 5, 4)]
        [TestCase(-10, -3, 3)]
        public void GetCoordinateQuater_WhenXYNotZero_ShouldGetQuater
            (int x, int y, int expected)
        {
            var actual = VariablesHelper.GetCoordinateQuater(x, y);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(0, 0)]
        public void GetCoordinateQuater_WhenXOrYIsZero_ShouldThrowArgumentException
            (int x, int y)
        {
            try
            {
                VariablesHelper.GetCoordinateQuater(x, y);
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }

            Assert.Fail("Argument exception should be thrown!");
        }

        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(0, 0)]
        public void GetCoordinateQuater_WhenXOrYIsZero_ShouldThrowArgumentException2
            (int x, int y)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                VariablesHelper.GetCoordinateQuater(x, y);
            });
        }

        [TestCase(new[] { 10, 5, 7, 3, 4, 1, 12 }, 5)]
        public void GetMinIndexOfArray_WhenArrayFilled_ShouldFindMinElementIndex
            (int[] array, int expected)
        {
            int actual = VariablesHelper.GetMinIndexOfArray(array);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[0], 10, -1)]
        [TestCase(new[] { 5 }, 2, -1)]
        [TestCase(new[] { 4 }, 4, 0)]
        [TestCase(new[] { 4, 7 }, 7, 1)]
        [TestCase(new[] { 5, -10 }, -11, -1)]
        [TestCase(new[] { 5, 3, 2, 10, 7 }, 2, 2)]
        [TestCase(new[] { 5, 2, 2, 54, 7 }, 2, 1)]
        [TestCase(new[] { -5, 3, 22, 110, 7 }, 115, -1)]
        [TestCase(new[] { 5, 3, 2, 7 }, 7, 3)]
        [TestCase(new[] { 5, 3, 2, 10, 7 }, 5, 0)]
        public void IndexOf_WhenArrayNotNull_ShouldFindIndexOfElement
            (int[] array, int searchedElement, int expected)
        {
            int actual = VariablesHelper.IndexOf(array, searchedElement);

            Assert.AreEqual(expected, actual);
        }

        private static object[] DataForMaxInMatrix =
        {
            new object[]
            {
                new[,]
                {
                    { 1, 2 },
                    { 3, 4}
                },
                4
            },
            new object[]{new[,] { { 1,2},{ 3, 10 }, { 3, 4 } }, 10}
        };

        [TestCaseSource(nameof(DataForMaxInMatrix))]
        public void GetMaxElementOfMatrix_WhenMatrixHasElements_ShouldFindMaxValue
            (int[,] matrix, int expected)
        {
            var actual = VariablesHelper.GetMaxElementOfMatrix(matrix);

            Assert.AreEqual(expected, actual);
        }

        private static object[] DataForSortMatrix =
        {
            new object[]
            {
                new[,]
                {
                    { 4, 3 },
                    { 2, 1}
                },
                new[,]
                {
                    { 1, 2 },
                    { 3, 4}
                },
            },
            new object[]
            {
                new[,]
                {
                    { 5, 7, 1 },
                    { 8, 2, 6}
                },
                new[,]
                {
                    { 1, 2, 5 },
                    { 6, 7, 8}
                },
            }
        };

        [TestCaseSource(nameof(DataForSortMatrix))]
        public void Sort_WhenMatrixNotNull_ShouldSortElements
            (int[,] matrix, int[,] expected)
        {
            VariablesHelper.Sort(matrix);

            CollectionAssert.AreEqual(expected, matrix);
        }
    }
}