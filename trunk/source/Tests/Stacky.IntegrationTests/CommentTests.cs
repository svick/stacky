using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests
{
    [TestClass]
    public class CommentTests : IntegrationTest
    {
        [TestMethod]
        public void Comments_GetComments()
        {
            var comments = Client.GetComments(22656);
            Assert.IsNotNull(comments);
        }

        [TestMethod]
        public void Comments_GetComments_ContainsPagingInformation()
        {
            var comments = Client.GetComments(22656);
            Assert.IsNotNull(comments);
            Assert.IsTrue(comments.PageSize > 0);
            Assert.IsTrue(comments.CurrentPage > 0);
            Assert.IsTrue(comments.TotalItems > 0);
        }

        [TestMethod]
        public void Comments_GetComments_Async()
        {
            ClientAsync.GetComments(22656, comments => Assert.IsNotNull(comments));
        }
    }
}