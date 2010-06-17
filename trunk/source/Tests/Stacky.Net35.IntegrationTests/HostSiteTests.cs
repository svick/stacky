using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests.Net35
{
    [TestClass]
    public class HostSiteTests
    {
        private StackyClient GetClient(Site site)
        {
            return new StackyClient(IntegrationTest.Version, IntegrationTest.ApiKey, site, new UrlClient(), new JsonProtocol());
        }

        [TestMethod]
        public void Stacky()
        {
            var client = GetClient(Sites.StackOverflow);
            var stats = client.GetSiteStats();
            Assert.IsNotNull(stats);
            Assert.IsNotNull(stats.Site);
            Assert.AreEqual("Stack Overflow", stats.Site.Name);
        }

        [TestMethod]
        public void ServerFault()
        {
            var client = GetClient(Sites.ServerFault);
            var stats = client.GetSiteStats();
            Assert.IsNotNull(stats);
            Assert.IsNotNull(stats.Site);
            Assert.AreEqual("Server Fault", stats.Site.Name);
        }

        [TestMethod]
        public void SuperUser()
        {
            var client = GetClient(Sites.SuperUser);
            var stats = client.GetSiteStats();
            Assert.IsNotNull(stats);
            Assert.IsNotNull(stats.Site);
            Assert.AreEqual("Super User", stats.Site.Name);
        }

        [TestMethod]
        public void Meta()
        {
            var client = GetClient(Sites.StackOverflowMeta);
            var stats = client.GetSiteStats();
            Assert.IsNotNull(stats);
            Assert.IsNotNull(stats.Site);
            Assert.AreEqual("Stack Overflow Meta", stats.Site.Name);
        }

        [TestMethod]
        public void StackApps()
        {
            var client = GetClient(Sites.StackApps);
            var stats = client.GetSiteStats();
            Assert.IsNotNull(stats);
            Assert.IsNotNull(stats.Site);
            Assert.AreEqual("Stack Apps", stats.Site.Name);
        }
    }
}