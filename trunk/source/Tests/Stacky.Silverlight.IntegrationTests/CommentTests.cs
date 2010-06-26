using System;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Stacky.Silverlight.IntegrationTests
{
    [TestClass]
    public class CommentTests : IntegrationTest
    {
        [TestMethod, Asynchronous]
        public void Comments_GetComments()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IEnumerable<Comment> received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    Client.GetComments(22656, results =>
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
        public void Comments_GetComments_ContainsPagingInformation()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IPagedList<Comment> received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    Client.GetComments(22656, results =>
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
        public void GetCommentsByPost_ByQuestionId()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IPagedList<Comment> received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    Client.GetCommentsByPost(9033, results =>
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
                EnqueueCallback(() => Assert.AreEqual(PostType.Question, received.FirstOrDefault().PostType));
            }
        }

        [TestMethod, Asynchronous]
        public void GetCommentsByPost_ByAnswerId()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IPagedList<Comment> received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    Client.GetCommentsByPost(11738, results =>
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
                EnqueueCallback(() => Assert.AreEqual(PostType.Answer, received.FirstOrDefault().PostType));
            }
        }

        [TestMethod, Asynchronous]
        public void GetAnswerComments()
        {
            using (var context = new AsynchronusTestContext(this))
            {
                IPagedList<Comment> received = null;
                ApiException exception = null;

                bool completed = false;
                EnqueueCallback(() =>
                {
                    Client.GetAnswerComments(1330865, results =>
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
                EnqueueCallback(() => Assert.AreEqual(PostType.Answer, received.FirstOrDefault().PostType));
            }
        }
    }
}
