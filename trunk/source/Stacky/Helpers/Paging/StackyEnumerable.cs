using System;
using System.Collections.Generic;

namespace Stacky
{
    public class StackyEnumerable<T> : IEnumerable<T>
            where T : class
    {
        public int? MaxNumItems { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; private set; }

        private Func<PagerInfo, IPagedList<T>> GetNext { get; set; }
        private T current = null;

        public StackyEnumerable(Func<PagerInfo, IPagedList<T>> getNext, int pageSize = 15, int? maxNumItems = null)
        {
            GetNext = getNext;
            PageSize = pageSize;
            MaxNumItems = maxNumItems;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new StackyEnumerator<T>(GetNext, PageSize, MaxNumItems);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.IEnumerator)GetEnumerator());
        }
    }
}