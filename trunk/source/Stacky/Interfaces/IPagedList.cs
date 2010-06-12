using System.Collections.Generic;

namespace Stacky
{
    public interface IPagedList<T> : IEnumerable<T>
    {
        int TotalItems { get; set; }
        int CurrentPage { get; set; }
        int PageSize { get; set; }
    }
}