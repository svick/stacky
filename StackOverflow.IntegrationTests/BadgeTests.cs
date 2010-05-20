using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackOverflow.IntegrationTests
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
        public void Badge_GetBadgesByUser()
        {
            var badges = Client.GetBadgesByUser(1464);
            Assert.IsNotNull(badges);
        }

        [TestMethod]
        public void Badge_GetBadges_Async()
        {
            ClientAsync.GetBadges(badges => Assert.IsNotNull(badges));
        }

        [TestMethod]
        public void Badge_GetBadgesByUser_Async()
        {
            ClientAsync.GetBadgesByUser(1464, badges => Assert.IsNotNull(badges));
        }
    }
}