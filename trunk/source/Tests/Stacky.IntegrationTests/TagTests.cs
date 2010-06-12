using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests
{
    [TestClass]
    public class TagTests : IntegrationTest
    {
        [TestMethod]
        public void Tag_GetTags()
        {
            var tags = Client.GetTags();
            Assert.IsNotNull(tags);
        }

        [TestMethod]
        public void Tag_GetTags_ContainsPagingInformation()
        {
            var tags = Client.GetTags();
            Assert.IsNotNull(tags);
            Assert.IsTrue(tags.PageSize > 0);
            Assert.IsTrue(tags.CurrentPage > 0);
            Assert.IsTrue(tags.TotalItems > 0);
        }

        [TestMethod]
        public void Tag_GetTags_Async()
        {
            ClientAsync.GetTags(tags => Assert.IsNotNull(tags));
        }

        [TestMethod]
        public void Tag_GetTagsByUser()
        {
            var tags = Client.GetTagsByUser(1464);
            Assert.IsNotNull(tags);
        }

        [TestMethod]
        public void Tag_GetTagsByUser_Async()
        {
            ClientAsync.GetTagsByUser(1464, tags => Assert.IsNotNull(tags));
        }
    }
}