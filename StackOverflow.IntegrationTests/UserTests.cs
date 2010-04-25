using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackOverflow.IntegrationTests
{
    [TestClass]
    public class UserTests : IntegrationTest
    {
        [TestMethod]
        public void User_Returns_Badge_Counts()
        {
            var user = Client.GetUser(1464);

            Assert.IsNotNull(user);
            Assert.IsNotNull(user.BadgeCounts);
            Assert.IsTrue(user.BadgeCounts.Bronze > 0);
        }
    }
}
