using System;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Stacky.Silverlight.IntegrationTests
{
    [TestClass]
    public class RevisionTests : IntegrationTest
    {
        [TestMethod, Asynchronous]
        public void Revision_GetRevisions()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IEnumerable<Revision> received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    Client.GetRevisions(31415, results =>
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
        public void Revision_GetRevision()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                Revision received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    Client.GetRevision(31415, Guid.Parse("5a1fd2ac-421a-43a9-a2a3-2e9b5afe1b23"), results =>
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
