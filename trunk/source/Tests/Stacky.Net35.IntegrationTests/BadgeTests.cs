using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests.Net35
{
    [TestClass]
    public class BadgeTests : IntegrationTest
    {
        [TestMethod]
        public void Badge_GetBadges()
        {
            var badges = Client.GetBadges();
            Assert.IsNotNull(badges);
        }

        [TestMethod]
        public void Badge_GetUsersByBadge()
        {
            var users = Client.GetUsersByBadge(1464);
            Assert.IsNotNull(users);
        }
    }
}