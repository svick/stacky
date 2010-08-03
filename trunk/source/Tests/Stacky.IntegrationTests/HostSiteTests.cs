using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests
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
            var questions = client.GetQuestions();
            Assert.IsNotNull(questions);
        }

        [TestMethod]
        public void ServerFault()
        {
            var client = GetClient(Sites.ServerFault);
            var questions = client.GetQuestions();
            Assert.IsNotNull(questions);
        }

        [TestMethod]
        public void SuperUser()
        {
            var client = GetClient(Sites.SuperUser);
            var questions = client.GetQuestions();
            Assert.IsNotNull(questions);
        }

        [TestMethod]
        public void Meta()
        {
            var client = GetClient(Sites.MetaStackOverflow);
            var questions = client.GetQuestions();
            Assert.IsNotNull(questions);
        }

        [TestMethod]
        public void StackApps()
        {
            var client = GetClient(Sites.StackApps);
            var questions = client.GetQuestions();
            Assert.IsNotNull(questions);
        }

        [TestMethod]
        public void GetSites()
        {
            var sites = AuthClient.GetSites();
            Assert.IsNotNull(sites);
        }

        [TestMethod]
        public void GetSites_ContainsStyling()
        {
            var sites = AuthClient.GetSites();
            Assert.IsNotNull(sites);
            foreach (var site in sites)
            {
                Assert.IsNotNull(site.Styling);
            }
        }

        [TestMethod]
        public void GetAssociatedUsers()
        {
            var users = AuthClient.GetAssociatedUsers(new Guid("05121a2b-3289-4965-a5f4-f26affeadc63"));
            Assert.IsNotNull(users);
        }
    }
}