using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests
{
    [TestClass]
    public class SiteStatsTests : IntegrationTest
    {
        [TestMethod]
        public void ContainsSite()
        {
            var stats = Client.GetSiteStats();
            Assert.IsNotNull(stats);
            Assert.IsNotNull(stats.Site);
        }

        [TestMethod]
        public void ContainsViewsPerDay()
        {
            var stats = Client.GetSiteStats();
            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.ViewsPerDay > 0);
        }
    }
}