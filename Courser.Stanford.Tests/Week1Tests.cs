using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coursera.Stanford.Implementations;

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

            for (int i = 0; i < expectedArray.Length; i++)
            {
                Assert.AreEqual(expectedArray[i], result.IntermediateArray[i], 0.05);
            }
        }

        
    }
}
