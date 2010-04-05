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
        [TestMethod]
        public void GetQuestion_ReturnsSingleQuestion()
        {
            StackOverflowClient client = new StackOverflowClient("0.5", new WebClient(), new JsonProtocol());
            var question = client.GetQuestion(2573290);
            Assert.IsNotNull(question);
        }

        [TestMethod]
        public void SiteStats_ReturnsSingleItem()
        {
            StackOverflowClient client = new StackOverflowClient("0.5", new WebClient(), new JsonProtocol());
            var stats = client.GetSiteStats();
            Assert.IsNotNull(stats);
        }
    }
}