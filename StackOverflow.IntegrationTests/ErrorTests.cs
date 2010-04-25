using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;

namespace StackOverflow.IntegrationTests
{
    [TestClass]
    public class ErrorTests : IntegrationTest
    {
        [TestMethod, ExpectedException(typeof(System.Net.WebException))]
        public void ErrorCode_404_NotFound_ThrowsError()
        {
            var error = Client.GetError(ErrorCode.NotFound);

            Assert.IsNotNull(error);
            Assert.AreEqual(error.Code, ErrorCode.NotFound);
        }

        [TestMethod]
        public void ErrorCode_InvalidApplicationPublicKey()
        {
            try
            {
                Client.GetError(ErrorCode.InvalidApplicationPublicKey);
            }
            catch (ApiException e)
            {
                Assert.AreEqual(e.Error.Code, ErrorCode.InvalidApplicationPublicKey);
            }
        }

        [TestMethod]
        public void ErrorCode_InvalidVectorFormat()
        {
            try
            {
                Client.GetError(ErrorCode.InvalidVectorFormat);
            }
            catch (ApiException e)
            {
                Assert.AreEqual(e.Error.Code, ErrorCode.InvalidVectorFormat);
            }            
        }
    }
}
