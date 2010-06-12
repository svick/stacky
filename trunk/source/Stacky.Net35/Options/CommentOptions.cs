using System;

namespace Stacky
{
    public class CommentOptions
    {
        public CommentSort SortBy = CommentSort.Creation;
        public SortDirection SortDirection = SortDirection.Descending;
        public int? ToUserId = null;
        public int? Page = null;
        public int? PageSize = null;
        public DateTime? FromDate = null;
        public DateTime? ToDate = null;
        public int? Min = null;
        public int? Max = null;
    }
}