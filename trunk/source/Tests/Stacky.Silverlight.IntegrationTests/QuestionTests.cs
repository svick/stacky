using System;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Stacky.Silverlight.IntegrationTests
{
    [TestClass]
    public class QuestionTests : IntegrationTest
    {
        [TestMethod, Asynchronous]
        public void Questions_GetQuestions()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IPagedList<Question> received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    Client.GetQuestions(results =>
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
        public void Question_Contains_Urls()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                Question received = null;
                ApiException exception = null;
                bool completed = false;

                EnqueueCallback(() =>
                {
                    Client.GetQuestion(31415, results =>
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
                EnqueueCallback(() => Assert.IsFalse(String.IsNullOrEmpty(received.CommentsUrl)));
                EnqueueCallback(() => Assert.IsFalse(String.IsNullOrEmpty(received.TimelineUrl)));
            }
        }

        [TestMethod, Asynchronous]
        public void Question_GetQuestionTimeline()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IEnumerable<PostEvent> received = null;
                ApiException exception = null;
                bool completed = false;

                EnqueueCallback(() =>
                {
                    Client.GetQuestionTimeline(31415, results =>
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
        public void Question_GetQuestion_ContainsOwner()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                Question received = null;
                ApiException exception = null;
                bool completed = false;

                Client.GetQuestion(2930182, results =>
                {
                    received = results;
                    completed = true;
                },
                error =>
                {
                    exception = error;
                    completed = true;
                });
                EnqueueConditional(() => completed);
                EnqueueCallback(() => Assert.IsNull(exception));
                EnqueueCallback(() => Assert.IsNotNull(received));
                EnqueueCallback(() => Assert.IsNotNull(received.Owner));
                EnqueueCallback(() => Assert.IsTrue(received.Owner.UserId.HasValue));
            }
        }

        [TestMethod, Asynchronous]
        public void Question_Search()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IPagedList<Question> received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    Client.Search(results =>
                    {
                        received = results;
                        completed = true;
                    },
                    error =>
                    {
                        exception = error;
                        completed = true;
                    }, inTitle: "Thread");
                });
                EnqueueConditional(() => completed);
                EnqueueCallback(() => Assert.IsNull(exception));
                EnqueueCallback(() => Assert.IsNotNull(received));
            }
        }
    }
}