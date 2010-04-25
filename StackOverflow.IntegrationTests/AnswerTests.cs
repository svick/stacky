using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackOverflow.IntegrationTests
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
    }
}
