using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackOverflow.Tests
{
    [TestClass]
    public class StackOverflowClientTests
    {
        private static string version = "0.8";
        private static string apiKey = "";
        private static string baseUrl = "api.stackoverflow.com";

        [TestMethod]
        public void GetQuestion_ReturnsSingleQuestion()
        {
            var client = new StackOverflowClient(version, apiKey, baseUrl, new UrlClient(), new JsonProtocol());
            var question = client.GetQuestion(2573290);
            Assert.IsNotNull(question);
        }

        [TestMethod]
        public void SiteStats_ReturnsSingleItem()
        {
            var client = new StackOverflowClient(version, apiKey, baseUrl, new UrlClient(), new JsonProtocol());
            var stats = client.GetSiteStats();
            Assert.IsNotNull(stats);
        }

        [TestMethod]
        [ExpectedException(typeof(ApiException))]
        public void InvalidVersionEror()
        {
            var client = new StackOverflowClient("unicorn", apiKey, baseUrl, new UrlClient(), new JsonProtocol());
            var question = client.GetQuestion(2573290);
        }
    }
}