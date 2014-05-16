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
        public void TrivialSmallInputCase()
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
        public void CountSplitInv_ReturnsInversionCount_TrivialCase()
        {
            var left = new long[] { 1, 3, 5 };
            var right = new long[] { 2, 4, 6 };
            var expectedInversionCount = 3;

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

            var expectedLeft = new long[] { 1, 3, 5 , 2};
            var expectedRight = new long[] { 4, 6, 7 };
            var result = sut.Split(input);

            AssertSequencesAreEqual(result.Item1, expectedLeft);
            AssertSequencesAreEqual(result.Item2, expectedRight);
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
                    Assert.Fail("Sequences have different number of elements");
            }
        }
    }
}
