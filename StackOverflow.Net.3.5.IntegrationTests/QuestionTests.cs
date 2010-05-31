using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public void GetQuestions_SortByActive_Desc()
        {
            var questions = Client.GetQuestions(new QuestionOptions
            {
                SortBy = QuestionSort.Active,
                SortDirection = SortDirection.Descending
            });

            Assert.IsNotNull(questions);
            Assert.AreEqual(30, questions.Count());
        }
    }
}