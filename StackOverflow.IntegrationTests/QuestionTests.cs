using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackOverflow.IntegrationTests
{
    public abstract class IntegrationTest
    {
        public IntegrationTest()
        {
            Client = new StackOverflowClient("0.5", new WebClient(), new JsonProtocol());
            ClientAsync = new StackOverflowClientAsync("0.5", new WebClientAsync(), new JsonProtocol());
        }

        public StackOverflowClient Client { get; set; }
        public StackOverflowClientAsync ClientAsync { get; set; }
    }

    [TestClass]
    public class QuestionTests : IntegrationTest
    {
        [TestMethod]
        public void GetQuestions_DefaultParamaters()
        {
            var questions = Client.GetQuestions();

            Assert.IsNotNull(questions);
            Assert.AreEqual(30, questions.Count);
        }

        #region GetQuestions - Sort By Active

        [TestMethod]
        public void GetQuestions_SortByActive_Desc()
        {
            var questions = Client.GetQuestions(sortBy: QuestionSort.Active, sortDirection: SortDirection.Descending);

            Assert.IsNotNull(questions);
            Assert.AreEqual(30, questions.Count);
        }

        [TestMethod]
        public void GetQuestions_SortByActive_Asc()
        {
            var questions = Client.GetQuestions(sortBy: QuestionSort.Active, sortDirection: SortDirection.Ascending);

            Assert.IsNotNull(questions);
            Assert.AreEqual(30, questions.Count);
        }

        [TestMethod]
        public void GetQuestions_SortByActive_WithPaging()
        {
            var questions = Client.GetQuestions(sortBy: QuestionSort.Active, page: 4, pageSize: 5);

            Assert.IsNotNull(questions);
            Assert.AreEqual(5, questions.Count);
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
            Assert.AreEqual(30, questions.Count);
        }

        [TestMethod]
        public void GetQuestions_SortByActive_WithDateRange()
        {
            var questions = Client.GetQuestions(sortBy: QuestionSort.Active, fromDate: new DateTime(2010, 1, 1), toDate: new DateTime(2010, 1, 25));

            Assert.IsNotNull(questions);
            Assert.AreEqual(30, questions.Count);
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
            Assert.AreEqual(30, questions.Count);
        }

        #endregion
    }
}
