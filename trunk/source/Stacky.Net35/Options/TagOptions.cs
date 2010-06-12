using System;

namespace Stacky
{
    public class TagOptions
    {
        public string Filter = null;
        public TagSort SortBy = TagSort.Popular;
        public SortDirection SortDirection = SortDirection.Descending;
        public int? Page = null;
        public int? PageSize = null;
        public DateTime? FromDate = null;
        public DateTime? ToDate = null;
        public int? Min = null;
        public int? Max = null;
    }
}