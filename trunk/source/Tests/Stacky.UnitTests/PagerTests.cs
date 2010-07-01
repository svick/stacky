using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.UnitTests
{
    [TestClass]
    public class StackyEnumerableTests
    {
        private IPagedList<T> CreateList<T>(int currentPage, int pageSize, int totalItems)
            where T : class, new()
        {
            List<T> list = new List<T>();
            for (int i = 0; i < pageSize; i++)
            {
                list.Add(new T());
            }
            return new PagedList<T>(list)
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        [TestMethod]
        public void Enumerable_ListWithNoItems_ShouldNotEnterLoop()
        {
            var enumerator = new StackyEnumerable<Question>(info =>
            {
                return CreateList<Question>(0, 0, 0);
            }, 5);

            foreach (var item in enumerator)
            {
                Assert.Fail("Should not have entered loop");
            }
        }

        [TestMethod]
        public void Enumerable_PageSizeOfZero_ShouldNotEnterLoop()
        {
            var enumerator = new StackyEnumerable<Question>(info =>
            {
                return CreateList<Question>(info.CurrentPage, info.PageSize, 0);
            }, 0);

            foreach (var item in enumerator)
            {
                Assert.Fail("Should not have entered loop");
            }
        }

        [TestMethod]
        public void Enumerable_StopsAtMaxItems()
        {
            int maxItems = 7;
            var enumerator = new StackyEnumerable<Question>(info =>
            {
                return CreateList<Question>(info.CurrentPage, info.PageSize, 10);
            }, 5, maxItems);

            int count = 0;
            foreach (var item in enumerator)
            {
                ++count;
            }
            Assert.AreEqual(maxItems, count);
        }

        [TestMethod]
        public void Enumerable_RetrievesNewPages_CorrectNumberOfTimes()
        {
            int numPageFetches = 0;
            var enumerator = new StackyEnumerable<Question>(info =>
            {
                ++numPageFetches;
                return CreateList<Question>(info.CurrentPage, info.PageSize, 100);
            }, 5);

            foreach (var item in enumerator)
            {
            }

            Assert.AreEqual(20, numPageFetches);
        }
    }

    [TestClass]
    public class PagerTests
    {
        private IPagedList<T> CreateList<T>(int currentPage, int pageSize, int totalItems)
            where T : class, new()
        {
            List<T> list = new List<T>();
            for (int i = 0; i < pageSize; i++)
            {
                list.Add(new T());
            }
            return new PagedList<T>(list)
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        [TestMethod]
        public void Pager_QueryWithNoResults_ShouldNotEnterLoop()
        {
            var pager = new Pager<Question>(info =>
            {
                return CreateList<Question>(0, 0, 0);
            }, 5);

            foreach(var page in pager)
            {
                Assert.Fail("Should not have entered loop");
            }
        }

        [TestMethod]
        public void Pager_PageSizeOfZero_ShouldNotEnterLoop()
        {
            var pager = new Pager<Question>(info =>
            {
                return CreateList<Question>(info.CurrentPage, info.PageSize, 0);
            }, 0);

            foreach (var page in pager)
            {
                Assert.Fail("Should not have entered loop");
            }
        }

        [TestMethod]
        public void Pager_PageSizeOfOne_ReturnsCorrectSizedList()
        {
            int pageSize = 1;
            var pager = new Pager<Question>(info =>
            {
                return CreateList<Question>(info.CurrentPage, info.PageSize, 10001);
            }, pageSize, 3);

            foreach (var page in pager)
            {
                Assert.AreEqual(pageSize, page.PageSize);
                Assert.AreEqual(pageSize, page.Count());
            }
        }

        [TestMethod]
        public void Pager_StopsAtMaxPages()
        {
            int maxNumPages = 5;
            var pager = new Pager<Question>(info =>
            {
                return CreateList<Question>(info.CurrentPage, info.PageSize, 10001);
            }, 5, 5);

            int i = 0;
            foreach (var page in pager)
            {
                ++i;
                if (i > 20) //just in case
                    Assert.Fail("Loop not stopping");
            }

            Assert.AreEqual(maxNumPages, i);
        }

        [TestMethod]
        public void Pager_CurrentPageIncrementsOnEachCall()
        {
            int maxNumPages = 5;
            int i = 0;
            var pager = new Pager<Question>(info =>
            {
                i = info.CurrentPage;
                return CreateList<Question>(info.CurrentPage, info.PageSize, 10001);
            }, 5, 5);

            
            foreach (var page in pager)
            {
                if (i > 20) //just in case
                    Assert.Fail("Loop not stopping");
            }

            Assert.AreEqual(maxNumPages, i);
        }
    }
}