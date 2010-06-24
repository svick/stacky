using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Stacky.IntegrationTests
{
    [TestClass]
    public class UserTests : IntegrationTest
    {
        [TestMethod]
        public void User_GetUsers()
        {
            var users = Client.GetUsers();
            Assert.IsNotNull(users);
        }

        [TestMethod]
        public void User_GetUsers_ContainsPagingInformation()
        {
            var users = Client.GetUsers();
            Assert.IsNotNull(users);
            Assert.IsTrue(users.PageSize > 0);
            Assert.IsTrue(users.CurrentPage > 0);
            Assert.IsTrue(users.TotalItems > 0);
        }

        [TestMethod]
        public void User_GetUserMentions()
        {
            var mentions = Client.GetUserMentions(22656);
            Assert.IsNotNull(mentions);
        }

        [TestMethod]
        public void User_GetUserMentions_ContainsPagingInformation()
        {
            var mentions = Client.GetUserMentions(22656);
            Assert.IsNotNull(mentions);
            Assert.IsTrue(mentions.PageSize > 0);
            Assert.IsTrue(mentions.CurrentPage > 0);
            Assert.IsTrue(mentions.TotalItems > 0);
        }

        [TestMethod]
        public void User_GetQuestionAnswers()
        {
            var answers = Client.GetQuestionAnswers(31415);
            Assert.IsNotNull(answers);
        }

        [TestMethod]
        public void User_GetQuestionAnswers_ContainsPagingInformation()
        {
            var answers = Client.GetQuestionAnswers(31415);
            Assert.IsNotNull(answers);
            Assert.IsTrue(answers.PageSize > 0);
            Assert.IsTrue(answers.CurrentPage > 0);
            Assert.IsTrue(answers.TotalItems > 0);
        }

        [TestMethod]
        public void User_GetUserTimeline()
        {
            var events = Client.GetUserTimeline(22656);
            Assert.IsNotNull(events);
        }

        [TestMethod]
        public void User_GetUserTimeline_ContainsPagingInformation()
        {
            var events = Client.GetUserTimeline(22656);
            Assert.IsNotNull(events);
            Assert.IsTrue(events.PageSize > 0);
            Assert.IsTrue(events.CurrentPage > 0);
            Assert.IsTrue(events.TotalItems > 0);
        }

        [TestMethod]
        public void User_GetUserReputation()
        {
            var rep = Client.GetUserReputation(22656);
            Assert.IsNotNull(rep);
        }

        [TestMethod]
        public void User_GetUserReputation_ContainsPagingInformation()
        {
            var rep = Client.GetUserReputation(22656);
            Assert.IsNotNull(rep);
            Assert.IsTrue(rep.PageSize > 0);
            Assert.IsTrue(rep.CurrentPage > 0);
            Assert.IsTrue(rep.TotalItems > 0);
        }

        [TestMethod]
        public void User_Returns_Badge_Counts()
        {
            var user = Client.GetUser(22656);

            Assert.IsNotNull(user);
            Assert.IsNotNull(user.BadgeCounts);
            Assert.IsTrue(user.BadgeCounts.Bronze > 0);
        }

        [TestMethod]
        public void User_Contains_Urls()
        {
            var user = Client.GetUser(22656);

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

        [TestMethod]
        public void GetModerators()
        {
            var users = Client.GetModerators();
            Assert.IsNotNull(users);
        }

        [TestMethod]
        public void UserHasAssociationId()
        {
            var user = Client.GetUser(646);
            Assert.IsNotNull(user);

            Assert.IsNotNull(user.AssociationId);
            Assert.IsFalse(user.AssociationId == Guid.Empty);
        }
    }
}