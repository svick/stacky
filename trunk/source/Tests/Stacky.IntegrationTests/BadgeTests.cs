using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests
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
            var users = Client.GetUsersByBadge(204);
            Assert.IsNotNull(users);
        }

        [TestMethod]
        public void Badge_GetTagBasedBadges()
        {
            var badges = Client.GetTagBasedBadges();
            Assert.IsNotNull(badges);
        }

        [TestMethod]
        public void Bug_2_GetUserBadges()
        {
            var badges = Client.GetUserBadges(1);
            Assert.IsNotNull(badges);
        }
    }
}