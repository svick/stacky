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
        public void ContainsDisplayName()
        {
            var stats = Client.GetSiteStats();
            Assert.IsNotNull(stats);
            Assert.IsFalse(String.IsNullOrEmpty(stats.DisplayName));
        }
    }
}
