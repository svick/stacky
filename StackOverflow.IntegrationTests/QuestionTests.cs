﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackOverflow.IntegrationTests
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
        public void Question_GetQuestions_Async()
        {
            ClientAsync.GetQuestions(questions => Assert.IsNotNull(questions));
        }

        #region GetQuestions - Sort By Active

        [TestMethod]
        public void GetQuestions_SortByActive_Desc()
        {
            var questions = Client.GetQuestions(sortBy: QuestionSort.Active, sortDirection: SortDirection.Descending);

            Assert.IsNotNull(questions);
            Assert.AreEqual(30, questions.Count());
        }

        [TestMethod]
        public void GetQuestions_SortByActive_Asc()
        {
            var questions = Client.GetQuestions(sortBy: QuestionSort.Active, sortDirection: SortDirection.Ascending);

            Assert.IsNotNull(questions);
            Assert.AreEqual(30, questions.Count());
        }

        [TestMethod]
        public void GetQuestions_SortByActive_WithPaging()
        {
            var questions = Client.GetQuestions(sortBy: QuestionSort.Active, page: 4, pageSize: 5);

            Assert.IsNotNull(questions);
            Assert.AreEqual(5, questions.Count());
        }

        [TestMethod]
        public void GetQuestions_SortByActive_WithTags()
        {
            var questions = Client.GetQuestions(sortBy: QuestionSort.Active, tags: new string[] { "lisp" });
            foreach (var question in questions)
            {
                Assert.IsTrue(question.Tags.Contains("lisp"));
            }

            Assert.IsNotNull(questions);
            Assert.AreEqual(30, questions.Count());
        }

        [TestMethod]
        public void GetQuestions_SortByActive_WithDateRange()
        {
            var questions = Client.GetQuestions(sortBy: QuestionSort.Active, fromDate: new DateTime(2010, 1, 1), toDate: new DateTime(2010, 1, 25));

            Assert.IsNotNull(questions);
            Assert.AreEqual(30, questions.Count());
        }

        [TestMethod]
        public void GetQuestions_SortByActive_WithBody()
        {
            var questions = Client.GetQuestions(sortBy: QuestionSort.Active, includeBody: true);

            foreach (var question in questions)
            {
                Assert.IsFalse(String.IsNullOrEmpty(question.Body));
            }

            Assert.IsNotNull(questions);
            Assert.AreEqual(30, questions.Count());
        }

        #endregion

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
        public void Question_GetQuestionTimeline_Async()
        {
            ClientAsync.GetQuestionTimeline(31415, events => Assert.IsNotNull(events));
        }

        [TestMethod]
        public void Question_Search()
        {
            var questions = Client.Search("Thread");
            Assert.IsNotNull(questions);
        }

        [TestMethod]
        public void Question_Search_Async()
        {
            ClientAsync.Search(questions => Assert.IsNotNull(questions), inTitle: "Thread");
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
    }
}