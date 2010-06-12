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
        private StackyClient GetClient(HostSite site)
        {
            return new StackyClient(IntegrationTest.Version, IntegrationTest.ApiKey, site, new UrlClient(), new JsonProtocol());
        }

        [TestMethod]
        public void HostSite_CanGetCustomAttribute()
        {
            var site = HostSite.StackOverflow;
            string address = site.GetAddress();

            Assert.AreEqual("api.stackoverflow.com", address);
        }

        [TestMethod]
        public void Stacky()
        {
            var client = GetClient(HostSite.StackOverflow);
            var stats = client.GetSiteStats();
            Assert.IsNotNull(stats);
            Assert.AreEqual("Stack Overflow", stats.DisplayName);
        }

        [TestMethod]
        public void ServerFault()
        {
            var client = GetClient(HostSite.ServerFault);
            var stats = client.GetSiteStats();
            Assert.IsNotNull(stats);
            Assert.AreEqual("Server Fault", stats.DisplayName);
        }

        [TestMethod]
        public void SuperUser()
        {
            var client = GetClient(HostSite.SuperUser);
            var stats = client.GetSiteStats();
            Assert.IsNotNull(stats);
            Assert.AreEqual("Super User", stats.DisplayName);
        }

        [TestMethod]
        public void Meta()
        {
            var client = GetClient(HostSite.Meta);
            var stats = client.GetSiteStats();
            Assert.IsNotNull(stats);
            Assert.AreEqual("Stack Overflow Meta", stats.DisplayName);
        }

        [TestMethod]
        public void StackApps()
        {
            var client = GetClient(HostSite.StackApps);
            var stats = client.GetSiteStats();
            Assert.IsNotNull(stats);
            Assert.AreEqual("Stack Apps", stats.DisplayName);
        }
    }
}