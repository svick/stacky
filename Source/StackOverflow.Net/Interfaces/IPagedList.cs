using System.Collections.Generic;

namespace StackOverflow
{
    public interface IPagedList<T> : IEnumerable<T>
    {
        int TotalItems { get; set; }
        int CurrentPage { get; set; }
        int PageSize { get; set; }
    }
}