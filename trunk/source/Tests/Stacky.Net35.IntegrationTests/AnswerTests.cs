using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests.Net35
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
        public void Answer_GetUsersAnswers_ContainsPagingInformation()
        {
            var answers = Client.GetUsersAnswers(1464);
            Assert.IsNotNull(answers);
            Assert.IsTrue(answers.PageSize > 0);
            Assert.IsTrue(answers.CurrentPage > 0);
            Assert.IsTrue(answers.TotalItems > 0);
        }

        [TestMethod]
        public void ContainsOwnerAsObject()
        {
            var answer = Client.GetUsersAnswers(1464).FirstOrDefault();

            Assert.IsNotNull(answer);
            Assert.IsNotNull(answer.Owner);
            Assert.IsNotNull(answer.Owner.DisplayName);
        }

        [TestMethod]
        public void Answer_GetAnswer()
        {
            var answer = Client.GetAnswer(11738);
            Assert.IsNotNull(answer);
        }

        [TestMethod]
        public void Answer_GetAnswers()
        {
            var answers = Client.GetAnswers(new int[] { 11738, 122784 });
            Assert.IsNotNull(answers);
        }
    }
}