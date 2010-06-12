using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests
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
            var questions = client.GetQuestions();
            Assert.IsNotNull(questions);
        }

        [TestMethod]
        public void ServerFault()
        {
            var client = GetClient(HostSite.ServerFault);
            var questions = client.GetQuestions();
            Assert.IsNotNull(questions);
        }

        [TestMethod]
        public void SuperUser()
        {
            var client = GetClient(HostSite.SuperUser);
            var questions = client.GetQuestions();
            Assert.IsNotNull(questions);
        }

        [TestMethod]
        public void Meta()
        {
            var client = GetClient(HostSite.Meta);
            var questions = client.GetQuestions();
            Assert.IsNotNull(questions);
        }

        [TestMethod]
        public void StackApps()
        {
            var client = GetClient(HostSite.StackApps);
            var questions = client.GetQuestions();
            Assert.IsNotNull(questions);
        }
    }
}