using System.Collections.Generic;

namespace Stacky
{
    public class PagedList<T> : IPagedList<T>
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public PagedList(IEnumerable<T> items)
        {
            Items = new List<T>(items);
        }

        public PagedList(IEnumerable<T> items, Response response)
            : this(items)
        {
            TotalItems = response.Total;
            CurrentPage = response.CurrentPage;
            PageSize = response.PageSize;
        }

        protected List<T> Items { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.IEnumerable)Items).GetEnumerator();
        }
    }
}