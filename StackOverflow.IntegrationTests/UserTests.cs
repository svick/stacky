using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackOverflow.IntegrationTests
{
    [TestClass]
    public class UserTests : IntegrationTest
    {
        [TestMethod]
        public void User_Returns_Badge_Counts()
        {
            var user = Client.GetUser(1464);

            Assert.IsNotNull(user);
            Assert.IsNotNull(user.BadgeCounts);
            Assert.IsTrue(user.BadgeCounts.Bronze > 0);
        }

        [TestMethod]
        public void User_Contains_Urls()
        {
            var user = Client.GetUser(1464);

            Assert.IsNotNull(user);
            Assert.IsFalse(String.IsNullOrEmpty(user.QuestionsUrl));
            Assert.IsFalse(String.IsNullOrEmpty(user.AnswersUrl));
            Assert.IsFalse(String.IsNullOrEmpty(user.FavoritesUrl));
            Assert.IsFalse(String.IsNullOrEmpty(user.TagsUrl));
            Assert.IsFalse(String.IsNullOrEmpty(user.BadgesUrl));
            Assert.IsFalse(String.IsNullOrEmpty(user.TimelineUrl));
            Assert.IsFalse(String.IsNullOrEmpty(user.MentionedUrl));
            Assert.IsFalse(String.IsNullOrEmpty(user.CommentsUrl));
            Assert.IsFalse(String.IsNullOrEmpty(user.ReputationUrl));
        }
    }
}
