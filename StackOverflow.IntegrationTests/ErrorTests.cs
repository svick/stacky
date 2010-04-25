using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackOverflow.IntegrationTests
{
    [TestClass]
    public class ErrorTests : IntegrationTest
    {
        //[TestMethod, ExpectedException(typeof(System.Net.WebException))]
        public void ErrorCode_404_NotFound_ThrowsError()
        {
            var error = Client.GetError(ErrorCode.NotFound);

            Assert.IsNotNull(error);
            Assert.AreEqual(error.Code, ErrorCode.NotFound);
        }

        //[TestMethod]
        public void ErrorCode_InvalidApplicationPublicKey()
        {
            var error = Client.GetError(ErrorCode.InvalidApplicationPublicKey);

            Assert.IsNotNull(error);
            Assert.AreEqual(error.Code, ErrorCode.InvalidApplicationPublicKey);
        }

        //[TestMethod]
        public void ErrorCode_InvalidVectorFormat()
        {
            var error = Client.GetError(ErrorCode.InvalidVectorFormat);

            Assert.IsNotNull(error);
            Assert.AreEqual(error.Code, ErrorCode.InvalidVectorFormat);
        }
    }
}
