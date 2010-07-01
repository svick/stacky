using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacky
{
    public class StackyEnumerator<T> : IEnumerator<T>
            where T : class
    {
        public int? MaxNumItems { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; private set; }
        private int CurrentItemIndex { get; set; }
        private int CurrentPageItemIndex { get; set; }

        private Func<PagerInfo, IPagedList<T>> GetNext { get; set; }
        private T currentItem = null;
        private IPagedList<T> currentPage = null;

        public StackyEnumerator(Func<PagerInfo, IPagedList<T>> getNext, int pageSize = 15, int? maxNumItems = null)
        {
            GetNext = getNext;
            PageSize = pageSize;
            MaxNumItems = maxNumItems;
        }

        public T Current
        {
            get { return currentItem; }
        }

        public void Dispose()
        {
        }

        object System.Collections.IEnumerator.Current
        {
            get { return currentItem; }
        }

        public bool MoveNext()
        {
            if ((PageSize <= 0 || CurrentItemIndex >= MaxNumItems) && CurrentPage > 0)
                return false;

            if (currentPage == null || CurrentPageItemIndex >= PageSize)
            {
                currentPage = GetNext(new PagerInfo { CurrentPage = ++CurrentPage, PageSize = PageSize });
                CurrentPageItemIndex = 0;
            }

            if (currentPage == null)
                return false;

            if (currentPage.TotalItems > 0)
            {
                currentItem = currentPage.ElementAt(CurrentPageItemIndex++);
                ++CurrentItemIndex;
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