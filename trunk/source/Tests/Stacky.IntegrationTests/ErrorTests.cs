using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Stacky.IntegrationTests
{
    [TestClass]
    public class ErrorTests : IntegrationTest
    {
        [TestMethod]
        public void InvalidSort_Returns_Underlying_ErrorCode()
        {
            HttpResponse httpResponse = Client.WebClient.MakeRequest(new Uri("http://api.stackoverflow.com/1.0/users/22656/mentioned/?key=&sort=reputation&order=desc"));
            Assert.IsNotNull(httpResponse.Error);
            try
            {
                var response = Client.ParseResponse<CommentResponse>(httpResponse);
            }
            catch (ApiException e)
            {
                Assert.IsNotNull(e.Error);
                Assert.AreEqual(ErrorCode.InvalidSort, e.Error.Code);
            }
        }

        [TestMethod]
        public void InvalidSort_Async_Returns_Underlying_ErrorCode()
        {
            ApiException exception = null;
            var waitHandle = new AutoResetEvent(false);
            ClientAsync.WebClient.MakeRequest(new Uri("http://api.stackoverflow.com/1.0/users/22656/mentioned/?key=&sort=reputation&order=desc"), response =>
            {
                waitHandle.Set();
            },
            error =>
            {
                exception = error;
                waitHandle.Set();
            });

            waitHandle.WaitOne();

            Assert.IsNotNull(exception);
            Assert.AreEqual(ErrorCode.InvalidSort, exception.Error.Code);
        }
    }
}