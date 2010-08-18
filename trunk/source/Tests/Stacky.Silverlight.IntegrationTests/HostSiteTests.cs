using System;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Stacky.Silverlight.IntegrationTests
{
    [TestClass]
    public class HostSiteTests : IntegrationTest
    {
        private StackyClient GetClient(Site site)
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
            var client = GetClient(Sites.StackOverflow);
            TestQuestionMethod(client);
        }

        [TestMethod, Asynchronous]
        public void ServerFault()
        {
            var client = GetClient(Sites.ServerFault);
            TestQuestionMethod(client);
        }

        [TestMethod, Asynchronous]
        public void SuperUser()
        {
            var client = GetClient(Sites.SuperUser);
            TestQuestionMethod(client);
        }

        [TestMethod, Asynchronous]
        public void Meta()
        {
            var client = GetClient(Sites.MetaStackOverflow);
            TestQuestionMethod(client);
        }

        [TestMethod, Asynchronous]
        public void StackApps()
        {
            var client = GetClient(Sites.StackApps);
            TestQuestionMethod(client);
        }

        [TestMethod, Asynchronous]
        public void GetSites()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IEnumerable<Site> received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    AuthClient.GetSites(results =>
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
        public void GetAssociatedUsers()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IEnumerable<AssociatedUser> received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    AuthClient.GetAssociatedUsers(new Guid("05121a2b-3289-4965-a5f4-f26affeadc63"), results =>
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
    }
}