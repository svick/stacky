using System;
using System.Collections.Generic;

namespace Stacky
{
    public class Pager<T> : IEnumerable<IPagedList<T>>
    {
        private Func<PagerInfo, IPagedList<T>> GetNext { get; set; }
        public int? MaxNumPages { get; set; }
        public int PageSize { get; set; }
        public static int DefaultPageSize = 15;
        public int CurrentPage { get; private set; }

        public Pager(Func<PagerInfo, IPagedList<T>> getNext, int pageSize = 15, int? maxNumPages = null)
        {
            GetNext = getNext;
            PageSize = pageSize;
            MaxNumPages = maxNumPages;
        }

        public IEnumerator<IPagedList<T>> GetEnumerator()
        {
            return new PageEnumerator<T>(GetNext, PageSize, MaxNumPages);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}