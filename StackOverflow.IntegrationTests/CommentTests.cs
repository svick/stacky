using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackOverflow.IntegrationTests
{
    [TestClass]
    public class CommentTests : IntegrationTest
    {
        [TestMethod]
        public void Comments_GetComments()
        {
            var comments = Client.GetComments(1464);
            Assert.IsNotNull(comments);
        }

        [TestMethod]
        public void Comments_GetComments_Async()
        {
            ClientAsync.GetComments(1464, comments => Assert.IsNotNull(comments));
        }
    }
}