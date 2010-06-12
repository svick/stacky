using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests
{
    [TestClass]
    public class AnswerTests : IntegrationTest
    {
        [TestMethod]
        public void Answer_Contains_Comments_Url()
        {
            var answer = Client.GetUsersAnswers(1464).FirstOrDefault();

            Assert.IsNotNull(answer);
            Assert.IsFalse(String.IsNullOrEmpty(answer.CommentsUrl));
        }

        [TestMethod]
        public void Answer_GetQuestionAnswers()
        {
            var answers = Client.GetQuestionAnswers(31415);
            Assert.IsNotNull(answers);
        }

        [TestMethod]
        public void Answer_GetQuestionAnswers_ContainsPagingInformation()
        {
            var answers = Client.GetQuestionAnswers(31415);
            Assert.IsNotNull(answers);
            Assert.IsTrue(answers.PageSize > 0);
            Assert.IsTrue(answers.CurrentPage > 0);
            Assert.IsTrue(answers.TotalItems > 0);
        }

        [TestMethod]
        public void Answer_GetQuestionAnswers_Async()
        {
            ClientAsync.GetQuestionAnswers(31415, answers => Assert.IsNotNull(answers));
        }

        [TestMethod]
        public void Answer_GetQuestionAnswers_Async_ContainsPagingInformation()
        {
            ClientAsync.GetQuestionAnswers(31415, answers =>
                {
                    Assert.IsNotNull(answers);
                    Assert.IsTrue(answers.PageSize > 0);
                    Assert.IsTrue(answers.CurrentPage > 0);
                    Assert.IsTrue(answers.TotalItems > 0);
                });
        }

        [TestMethod]
        public void Answer_GetUsersAnswers_ContainsPagingInformation()
        {
            var answers = Client.GetUsersAnswers(1464);
            Assert.IsNotNull(answers);
            Assert.IsTrue(answers.PageSize > 0);
            Assert.IsTrue(answers.CurrentPage > 0);
            Assert.IsTrue(answers.TotalItems > 0);
        }
    }
}
