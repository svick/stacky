using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests.Net35
{
    [TestClass]
    public class QuestionTests : IntegrationTest
    {
        [TestMethod]
        public void Question_GetQuestions()
        {
            var questions = Client.GetQuestions();
            Assert.IsNotNull(questions);
        }

        [TestMethod]
        public void GetQuestions_SortByActive_Desc()
        {
            var questions = Client.GetQuestions(new QuestionOptions
            {
                SortBy = QuestionSort.Activity,
                SortDirection = SortDirection.Descending
            });

            Assert.IsNotNull(questions);
            Assert.AreEqual(30, questions.Count());
        }

        [TestMethod]
        public void Question_Contains_Urls()
        {
            var question = Client.GetQuestion(31415);

            Assert.IsNotNull(question);
            Assert.IsFalse(String.IsNullOrEmpty(question.CommentsUrl));
            Assert.IsFalse(String.IsNullOrEmpty(question.TimelineUrl));
        }

        [TestMethod]
        public void Question_GetQuestionTimeline()
        {
            var events = Client.GetQuestionTimeline(31415);
            Assert.IsNotNull(events);
        }

        [TestMethod]
        public void Question_Search()
        {
            var questions = Client.Search(new QuestionSearchOptions
            {
                InTitle = "Thread"
            });
            Assert.IsNotNull(questions);
        }

        [TestMethod]
        public void Question_GetQuestions_HasPagingInformation()
        {
            var questions = Client.GetQuestions();
            Assert.IsNotNull(questions);
            Assert.IsTrue(questions.PageSize > 0);
            Assert.IsTrue(questions.CurrentPage > 0);
            Assert.IsTrue(questions.TotalItems > 0);
        }

        [TestMethod]
        public void Question_GetQuestion_ContainsOwner()
        {
            var question = Client.GetQuestion(2930182);
            Assert.IsNotNull(question);
            Assert.IsNotNull(question.Owner);
            Assert.IsNotNull(question.Owner.UserId);
        }
    }
}