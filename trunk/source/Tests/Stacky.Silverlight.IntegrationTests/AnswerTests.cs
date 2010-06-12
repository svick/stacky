using System;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Stacky.Silverlight.IntegrationTests
{
    [TestClass]
    public class AnswerTests : IntegrationTest
    {
        [TestMethod, Asynchronous]
        public void Answer_Contains_Comments_Url()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                Answer received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    Client.GetUsersAnswers(1464, results =>
                    {
                        received = results.FirstOrDefault();
                        completed = true;
                    },
                    error =>
                    {
                        exception = error;
                        completed = true;
                    });
                });
                EnqueueConditional(() => completed);
                EnqueueCallback(() => Assert.IsNull(exception));
                EnqueueCallback(() => Assert.IsNotNull(received));
                EnqueueCallback(() => Assert.IsNotNull(received.CommentsUrl));
            }
        }

        [TestMethod, Asynchronous]
        public void Answer_GetQuestionAnswers()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IPagedList<Answer> received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    Client.GetQuestionAnswers(31415, results =>
                    {
                        received = results;
                        completed = true;
                    },
                    error =>
                    {
                        exception = error;
                        completed = true;
                    });
                });
                EnqueueConditional(() => completed);
                EnqueueCallback(() => Assert.IsNull(exception));
                EnqueueCallback(() => Assert.IsNotNull(received));
            }
        }

        [TestMethod, Asynchronous]
        public void Answer_GetQuestionAnswers_ContainsPagingInformation()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IPagedList<Answer> received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    Client.GetQuestionAnswers(31415, results =>
                    {
                        received = results;
                        completed = true;
                    },
                    error =>
                    {
                        exception = error;
                        completed = true;
                    });
                });
                EnqueueConditional(() => completed);
                EnqueueCallback(() => Assert.IsNull(exception));
                EnqueueCallback(() => Assert.IsNotNull(received));
                EnqueueCallback(() => Assert.IsTrue(received.PageSize > 0));
                EnqueueCallback(() => Assert.IsTrue(received.CurrentPage > 0));
                EnqueueCallback(() => Assert.IsTrue(received.TotalItems > 0));
            }
        }

        [TestMethod, Asynchronous]
        public void Answer_GetUsersAnswers_ContainsPagingInformation()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IPagedList<Answer> received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    Client.GetUsersAnswers(1464, results =>
                    {
                        received = results;
                        completed = true;
                    },
                    error =>
                    {
                        exception = error;
                        completed = true;
                    });
                });
                EnqueueConditional(() => completed);
                EnqueueCallback(() => Assert.IsNull(exception));
                EnqueueCallback(() => Assert.IsNotNull(received));
                EnqueueCallback(() => Assert.IsTrue(received.PageSize > 0));
                EnqueueCallback(() => Assert.IsTrue(received.CurrentPage > 0));
                EnqueueCallback(() => Assert.IsTrue(received.TotalItems > 0));
            }
        }
    }
}