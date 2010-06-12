using System;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Stacky.Silverlight.IntegrationTests
{
    [TestClass]
    public class TagTests : IntegrationTest
    {
        [TestMethod, Asynchronous]
        public void Tag_GetTags()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IPagedList<Tag> received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    Client.GetTags(results =>
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
        public void Tag_GetTags_ContainsPagingInformation()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IPagedList<Tag> received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    Client.GetTags(results =>
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
                EnqueueCallback(() => Assert.IsTrue(received.PageSize > 0));
                EnqueueCallback(() => Assert.IsTrue(received.CurrentPage > 0));
                EnqueueCallback(() => Assert.IsTrue(received.TotalItems > 0));
            }
        }

        [TestMethod, Asynchronous]
        public void Tag_GetTagsByUser()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IPagedList<Tag> received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    Client.GetTagsByUser(1464, results =>
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