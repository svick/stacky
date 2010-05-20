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

        [TestMethod]
        public void GetQuestion_ReturnsSingleQuestion()
        {
            var client = new StackOverflowClient(version, apiKey, new UrlClient(), new JsonProtocol());
            var question = client.GetQuestion(2573290);
            Assert.IsNotNull(question);
        }

        [TestMethod]
        public void SiteStats_ReturnsSingleItem()
        {
            var client = new StackOverflowClient(version, apiKey, new UrlClient(), new JsonProtocol());
            var stats = client.GetSiteStats();
            Assert.IsNotNull(stats);
        }
    }
}