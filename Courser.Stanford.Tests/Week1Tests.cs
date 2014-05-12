using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coursera.Stanford.Implementations;

namespace Courser.Stanford.Tests
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
    }
}
