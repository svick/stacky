using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests.Net35
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
        public void GetCommentsByPost_ByQuestionId()
        {
            var comments = Client.GetCommentsByPost(9033);
            Assert.IsNotNull(comments);
            Assert.AreEqual(PostType.Question, comments.FirstOrDefault().PostType);
        }

        [TestMethod]
        public void GetCommentsByPost_ByAnswerId()
        {
            var comments = Client.GetCommentsByPost(11738);
            Assert.IsNotNull(comments);
            Assert.AreEqual(PostType.Answer, comments.FirstOrDefault().PostType);
        }
    }
}