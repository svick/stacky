﻿using System;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace StackOverflow.Net.Silverlight.IntegrationTests
{
    [TestClass]
    public class SiteStatsTests : IntegrationTest
    {
        [TestMethod, Asynchronous]
        public void ContainsDisplayName()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                SiteStats received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    Client.GetSiteStats(results =>
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
                EnqueueCallback(() => Assert.IsFalse(String.IsNullOrEmpty(received.DisplayName)));
            }
        }
    }
}
