using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests
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
        public void Revision_GetRevisions_Async()
        {
            ClientAsync.GetRevisions(31415, revisions => Assert.IsNotNull(revisions));
        }

        [TestMethod]
        public void Revision_GetRevision()
        {
            var revision = Client.GetRevision(31415, Guid.Parse("5a1fd2ac-421a-43a9-a2a3-2e9b5afe1b23"));
            Assert.IsNotNull(revision);
        }

        [TestMethod]
        public void Revision_GetRevision_Async()
        {
            ClientAsync.GetRevision(31415, Guid.Parse("5a1fd2ac-421a-43a9-a2a3-2e9b5afe1b23"), revision => Assert.IsNotNull(revision));
        }
    }
}