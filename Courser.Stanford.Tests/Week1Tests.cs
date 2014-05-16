using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coursera.Stanford.Implementations;
using System.Collections.Generic;
using System.Linq;

namespace Coursera.Stanford.Tests
{
    [TestClass]
    public class Week1Tests
    {
        private InversionCalculationImpl sut;

        [TestInitialize]
        public void SetUp()
        {
            sut = new InversionCalculationImpl();
        }

        [TestMethod]
        public void Calc_TrivialSmallInputCase()
        {
            var input = new long[] { 1, 3, 5, 2, 4, 6 };

            var result = sut.Calc(input);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void CountSplitInv_ReturnsSortedArray()
        {
            var left = new long[] { 1, 3, 5 };
            var right = new long[] { 2, 4, 6 };
            var expectedArray = new long[] { 1, 2, 3, 4, 5, 6 };

            var result = sut.CountSplitInv(left, right);

            AssertSequencesAreEqual(expectedArray, result.IntermediateArray);
        }

        [TestMethod]
        public void CountSplitInv_OneElementArrays_ReturnsSortedArray()
        {
            var left = new long[] { 1 };
            var right = new long[] { 2 };
            var expectedArray = new long[] { 1, 2 };

            var result = sut.CountSplitInv(left, right);

            AssertSequencesAreEqual(expectedArray, result.IntermediateArray);
        }

        [TestMethod]
        public void CountSplitInv_NoElementArrays_ReturnsSortedArray()
        {
            var left = new long[] { };
            var right = new long[] { };

            var result = sut.CountSplitInv(left, right);

            Assert.AreEqual(0, result.IntermediateArray.Length);
        }

        [TestMethod]
        public void CountSplitInv_ReturnsInversionCount_TrivialCase()
        {
            var left = new long[] { 1, 3, 5 };
            var right = new long[] { 2, 4, 6 };
            var expectedInversionCount = 3;

            var result = sut.CountSplitInv(left, right);

            Assert.AreEqual(expectedInversionCount, result.Count);
        }

        [TestMethod]
        public void CountSplitInv_EqualArrays_ReturnsNoInversions()
        {
            var left = new long[] { 1 };
            var right = new long[] { 1 };
            var expectedInversionCount = 0;

            var result = sut.CountSplitInv(left, right);

            Assert.AreEqual(expectedInversionCount, result.Count);
        }

        [TestMethod]
        public void Split_EvenNumberOfElements_ReturnsTwoEqualArrays()
        {
            var input = new long[] { 1, 3, 5, 2, 4, 6 };

            var expectedLeft = new long[] { 1, 3, 5 };
            var expectedRight = new long[] { 2, 4, 6 };
            var result = sut.Split(input);

            Assert.AreEqual(result.Item1.Length, result.Item2.Length);
            AssertSequencesAreEqual(result.Item1, expectedLeft);
            AssertSequencesAreEqual(result.Item2, expectedRight);
        }

        [TestMethod]
        public void Split_OddNumberOfElements_FirstArrayIsLarger()
        {
            var input = new long[] { 1, 3, 5, 2, 4, 6, 7 };

            var expectedLeft = new long[] { 1, 3, 5, 2 };
            var expectedRight = new long[] { 4, 6, 7 };
            var result = sut.Split(input);

            AssertSequencesAreEqual(result.Item1, expectedLeft);
            AssertSequencesAreEqual(result.Item2, expectedRight);
        }

        [TestMethod]
        public void Calc_EmptyInput_ReturnsZero()
        {
            //got that from the Coursera discussion forums: https://class.coursera.org/algo-005/forum/thread?thread_id=31
            var input = new long[] { };
            var expected = 0;
            AssertMainRoutine(input, expected);
        }

        [TestMethod]
        public void Calc_CountSplitInversions()
        {
            //got that from the Coursera discussion forums: https://class.coursera.org/algo-005/forum/thread?thread_id=31
            var input = new long[] { 1, 1, 0 };
            var expected = 2;
            AssertMainRoutine(input, expected);
        }

        [TestMethod]
        public void Calc_AccumulateLeftInversions()
        {
            //got that from the Coursera discussion forums: https://class.coursera.org/algo-005/forum/thread?thread_id=31
            var input = new long[] { 1, 0, 1, 1 };
            var expected = 1;
            AssertMainRoutine(input, expected);
        }

        [TestMethod]
        public void Calc_ModerateArray()
        {
            //got that from the Coursera discussion forums: https://class.coursera.org/algo-005/forum/thread?thread_id=31
            var input = new long[] { 4, 80, 70, 23, 9, 60, 68, 27, 66, 78, 12, 40, 52, 53, 44, 8, 49, 28, 18, 46, 21, 39, 51, 7, 87, 99, 69, 62, 84, 6, 79, 67, 14, 98, 83, 0, 96, 5, 82, 10, 26, 48, 3, 2, 15, 92, 11, 55, 63, 97, 43, 45, 81, 42, 95, 20, 25, 74, 24, 72, 91, 35, 86, 19, 75, 58, 71, 47, 76, 59, 64, 93, 17, 50, 56, 94, 90, 89, 32, 37, 34, 65, 1, 73, 41, 36, 57, 77, 30, 22, 13, 29, 38, 16, 88, 61, 31, 85, 33, 54 };
            var expected = 2372;
            AssertMainRoutine(input, expected);
        }

        [TestMethod]
        public void CountAndSort_ReturnsSortedArray()
        {
            //got that from the Coursera discussion forums: https://class.coursera.org/algo-005/forum/thread?thread_id=31
            var input = new long[] { 9, 12, 3 };
            var expected = input.OrderBy(d => d).ToArray();

            var result = sut.CountAndSort(input);
            AssertSequencesAreEqual(expected, result.IntermediateArray);
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void CountSplitInv_UnequalImputs_ReturnsSortedArray()
        {
            //got that from the Coursera discussion forums: https://class.coursera.org/algo-005/forum/thread?thread_id=31
            var left = new long[] { 9, 12 };
            var right = new long[] { 3 };
            var expected = new long[] { 3, 9, 12 };

            var result = sut.CountSplitInv(left, right);
            AssertSequencesAreEqual(expected, result.IntermediateArray);
        }

        private void AssertMainRoutine(long[] input, int expected)
        {
            var result = sut.Calc(input);

            Assert.AreEqual(expected, result);
        }

        public void AssertSequencesAreEqual<T>(IEnumerable<T> left, IEnumerable<T> right)
        {
            var leftEn = left.GetEnumerator();
            var rightEn = right.GetEnumerator();

            while (leftEn.MoveNext())
            {
                if (!rightEn.MoveNext())
                    Assert.Fail("Sequences have different number of elements");

                if (!leftEn.Current.Equals(rightEn.Current))
                    Assert.Fail("Sequences have different elements");
            }
        }
    }
}
