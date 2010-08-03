using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests.Net35
{
    [TestClass]
    public class HostSiteTests : IntegrationTest
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
            var client = GetClient(Sites.MetaStackOverflow);
            var stats = client.GetSiteStats();
            Assert.IsNotNull(stats);
            Assert.IsNotNull(stats.Site);
            Assert.AreEqual("Meta Stack Overflow", stats.Site.Name);
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

        [TestMethod]
        public void GetSites()
        {
            var sites = AuthClient.GetSites();
            Assert.IsNotNull(sites);
        }

        [TestMethod]
        public void GetAssociatedUsers()
        {
            var users = AuthClient.GetAssociatedUsers(new Guid("05121a2b-3289-4965-a5f4-f26affeadc63"));
            Assert.IsNotNull(users);
        }
    }
}