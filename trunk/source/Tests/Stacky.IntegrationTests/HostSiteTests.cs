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
            var client = GetClient(Sites.StackOverflowMeta);
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
    }
}