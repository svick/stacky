using System;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Stacky.Silverlight.IntegrationTests
{
    [TestClass]
    public class HostSiteTests : SilverlightTest
    {
        private StackyClient GetClient(HostSite site)
        {
            return new StackyClient(IntegrationTest.Version, IntegrationTest.ApiKey, site, new UrlClient(), new JsonProtocol());
        }

        private void TestQuestionMethod(StackyClient client)
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IEnumerable<Question> received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    client.GetQuestions(results =>
                    {
                        received = results;
                        completed = true;
                    },
                    error =>
                    {
                        exception = error;
                        completed = true;
                    });
                });
                EnqueueConditional(() => completed);
                EnqueueCallback(() => Assert.IsNull(exception));
                EnqueueCallback(() => Assert.IsNotNull(received));
            }
        }

        [TestMethod, Asynchronous]
        public void Stacky()
        {
            var client = GetClient(HostSite.StackOverflow);
            TestQuestionMethod(client);
        }

        [TestMethod, Asynchronous]
        public void ServerFault()
        {
            var client = GetClient(HostSite.ServerFault);
            TestQuestionMethod(client);
        }

        [TestMethod, Asynchronous]
        public void SuperUser()
        {
            var client = GetClient(HostSite.SuperUser);
            TestQuestionMethod(client);
        }

        [TestMethod, Asynchronous]
        public void Meta()
        {
            var client = GetClient(HostSite.Meta);
            TestQuestionMethod(client);
        }

        [TestMethod, Asynchronous]
        public void StackApps()
        {
            var client = GetClient(HostSite.StackApps);
            TestQuestionMethod(client);
        }
    }
}