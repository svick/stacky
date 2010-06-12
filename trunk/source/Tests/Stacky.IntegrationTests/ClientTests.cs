using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests
{
    [TestClass]
    public class ClientTests : IntegrationTest
    {
        [TestMethod]
        public void RequestsRemainingPopulated()
        {
            var questions = Client.GetQuestions();
            Assert.IsTrue(Client.RemainingRequests > 0);
        }

        [TestMethod]
        public void MaxRequestsPopulated()
        {
            var questions = Client.GetQuestions();
            Assert.IsTrue(Client.MaxRequests > 0);
        }
    }
}
