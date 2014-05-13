using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Reflectiondm.Utils.Tests
{
    [TestClass]
    public class FileHelperTests
    {
        [TestMethod]
        [TestCategory("Integration")]
        public void GetArrayFromFile_Success()
        {
            var result = FileHelper.GetArrayFromFile("IntegerArray.txt");

            Assert.AreEqual(54044, result[0]);
            Assert.AreEqual(100000, result.Length);
            Assert.AreEqual(91901, result[99999]);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        [TestCategory("Integration")]
        public void GetArrayFromFile_NoFile_ThrowsFileNotFound()
        {
            var result = FileHelper.GetArrayFromFile("NonExist.ext");
        }
    }
}
