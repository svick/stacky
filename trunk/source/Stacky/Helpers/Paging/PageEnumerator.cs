using System;
using System.Collections.Generic;

namespace Stacky
{
    internal class PageEnumerator<T> : IEnumerator<IPagedList<T>>
    {
        public int? MaxNumPages { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; private set; }

        private Func<PagerInfo, IPagedList<T>> GetNext { get; set; }
        private IPagedList<T> current = null;

        public PageEnumerator(Func<PagerInfo, IPagedList<T>> getNext, int pageSize = 15, int? maxNumPages = null)
        {
            GetNext = getNext;
            PageSize = pageSize;
            MaxNumPages = maxNumPages;
        }

        public IPagedList<T> Current
        {
            get { return current; }
        }

        public void Dispose()
        {
        }

        object System.Collections.IEnumerator.Current
        {
            get { return current; }
        }

        public bool MoveNext()
        {
            if ((PageSize <= 0 || CurrentPage >= MaxNumPages) && CurrentPage > 0)
                return false;
            try
            {
                current = GetNext(new PagerInfo { CurrentPage = ++CurrentPage, PageSize = PageSize });
            }
            catch (Exception)
            {
                return false;
            }
            if (current == null)
                return false;
            if (current.TotalItems > 0)
            {
                return true;
            }
            return false;
        }

        public void Reset()
        {
            CurrentPage = 0;
        }
    }
}