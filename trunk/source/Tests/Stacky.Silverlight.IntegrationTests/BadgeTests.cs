using System;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Stacky.Silverlight.IntegrationTests
{
    [TestClass]
    public class BadgeTests : IntegrationTest
    {
        [TestMethod, Asynchronous]
        public void Badge_GetBadges()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IEnumerable<Badge> received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    Client.GetBadges(results =>
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
        public void Badge_GetUsersByBadge()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IPagedList<User> received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    Client.GetUsersByBadge(204, results =>
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
        public void Badge_GetTagBasedBadges()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IEnumerable<Badge> received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    Client.GetTagBasedBadges(results =>
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
