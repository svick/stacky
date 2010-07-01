using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests
{
    [TestClass]
    public class PagerTests : IntegrationTest
    {
        [TestMethod]
        public void PageBadges()
        {
            var pager = new Pager<Question>(info =>
            {
                return Client.GetQuestions(QuestionSort.Votes, SortDirection.Ascending, info.CurrentPage, info.PageSize);
            }, 5, 5);

            foreach(var page in pager)
            {
                Assert.IsNotNull(page);
            }
        }

        [TestMethod]
        public void EnumerateUsers()
        {
            int pageFetches = 0;
            var enumerator = new StackyEnumerable<User>(info =>
            {
                ++pageFetches;
                return Client.GetUsers(page: info.CurrentPage, pageSize: info.PageSize);
            }, 20, 40);

            int count = 0;
            foreach (var user in enumerator)
            {
                ++count;
            }

            Assert.AreEqual(40, count);
            Assert.AreEqual(2, pageFetches);
        }
    }
}