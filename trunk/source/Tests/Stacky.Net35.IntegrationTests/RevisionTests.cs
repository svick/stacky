using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests.Net35
{
    [TestClass]
    public class RevisionTests : IntegrationTest
    {
        [TestMethod]
        public void Revision_GetRevisions()
        {
            var revisions = Client.GetRevisions(31415);
            Assert.IsNotNull(revisions);
        }

        [TestMethod]
        public void Revision_GetRevision()
        {
            var revision = Client.GetRevision(31415, new Guid("5a1fd2ac-421a-43a9-a2a3-2e9b5afe1b23"));
            Assert.IsNotNull(revision);
        }
    }
}