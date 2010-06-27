using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacky
{
    internal class StackyEnumerator<T> : IEnumerator<T>
    {
        private Func<PagerInfo, IPagedList<T>> GetNext { get; set; }
        public int PageSize { get; set; }
        
        private T current = default(T);
        private IPagedList<T> CurrentPage { get; set; }
        private int CurrentIndex { get; set; }
        public int CurrentPageNumber { get; set; }


        public StackyEnumerator(Func<PagerInfo, IPagedList<T>> getNext, int pageSize)
        {
            GetNext = getNext;
            PageSize = pageSize;
        }

        public T Current
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
            if (CurrentPage == null)
                CurrentPage = GetNext(new PagerInfo { PageSize = PageSize, CurrentPage = ++CurrentPageNumber });
            current = CurrentPage.ElementAtOrDefault(CurrentIndex++);
            return true;
        }

        public void Reset()
        {
        }
    }


    public class StackyEnumerable<T> : IEnumerable<T>
    {
        public StackyEnumerable(Func<PagerInfo, IPagedList<T>> getNext, int numItems, int pageSize = 30)
        {
            GetNext = getNext;
            PageSize = pageSize;
            NumItems = numItems;
        }

        private Func<PagerInfo, IPagedList<T>> GetNext { get; set; }
        public int PageSize { get; set; }
        public int NumItems { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return new StackyEnumerator<T>(GetNext, PageSize);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.IEnumerator)GetEnumerator());
        }
    }

    public class Pager<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public IPagedList<T> CurrentItems { get; set; }

        private Func<StackyClient, PagerInfo, IPagedList<T>> GetNext { get; set; }
        private StackyClient Client { get; set; }

        public Pager(Func<StackyClient, PagerInfo, IPagedList<T>> getNext, StackyClient client, int pageSize)
        {
            GetNext = getNext;
            Client = client;
            PageSize = pageSize;
        }

        public bool GetNextPage()
        {
            //if (CurrentPage >= TotalPages)
            //    return false;
            CurrentItems = GetNext(Client, new PagerInfo { CurrentPage = ++CurrentPage, PageSize = PageSize });
            return true;
        }
    }

    public class PagerInfo
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
