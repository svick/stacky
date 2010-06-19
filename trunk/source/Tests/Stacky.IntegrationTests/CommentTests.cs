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
        public void Comment_ContainsOwnerAsObject()
        {
            var comment = Client.GetComments(22656).FirstOrDefault();

            Assert.IsNotNull(comment);
            Assert.IsNotNull(comment.Owner);
            Assert.IsNotNull(comment.Owner.DisplayName);
        }
    }
}