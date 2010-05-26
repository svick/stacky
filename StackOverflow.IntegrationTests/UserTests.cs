using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackOverflow.IntegrationTests
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
        public void User_GetUsers_Async()
        {
            ClientAsync.GetUsers(users => Assert.IsNotNull(users));
        }

        [TestMethod]
        public void User_GetUserMentions()
        {
            var mentions = Client.GetUserMentions(1464);
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
        public void User_GetUserMentions_Async()
        {
            ClientAsync.GetUserMentions(1464, mentions => Assert.IsNotNull(mentions));
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
        public void User_GetQuestionAnswers_Async()
        {
            ClientAsync.GetQuestionAnswers(31415, answers => Assert.IsNotNull(answers));
        }

        [TestMethod]
        public void User_GetUserTimeline()
        {
            var events = Client.GetUserTimeline(1464);
            Assert.IsNotNull(events);
        }

        [TestMethod]
        public void User_GetUserTimeline_ContainsPagingInformation()
        {
            var events = Client.GetUserTimeline(1464);
            Assert.IsNotNull(events);
            Assert.IsTrue(events.PageSize > 0);
            Assert.IsTrue(events.CurrentPage > 0);
            Assert.IsTrue(events.TotalItems > 0);
        }

        [TestMethod]
        public void User_GetUserTimeline_Async()
        {
            ClientAsync.GetUserTimeline(1464, events => Assert.IsNotNull(events));
        }

        [TestMethod]
        public void User_GetUserReputation()
        {
            var rep = Client.GetUserReputation(1464);
            Assert.IsNotNull(rep);
        }

        [TestMethod]
        public void User_GetUserReputation_ContainsPagingInformation()
        {
            var rep = Client.GetUserReputation(1464);
            Assert.IsNotNull(rep);
            Assert.IsTrue(rep.PageSize > 0);
            Assert.IsTrue(rep.CurrentPage > 0);
            Assert.IsTrue(rep.TotalItems > 0);
        }

        [TestMethod]
        public void User_GetUserReputation_Async()
        {
            ClientAsync.GetUserReputation(1464, rep => Assert.IsNotNull(rep));
        }

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