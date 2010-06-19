using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacky
{
    public class CommentsByPostOptions
    {
        public CommentSort SortBy = CommentSort.Creation;
        public SortDirection SortDirection = SortDirection.Descending;
        public int? Page = null;
        public int? PageSize = null;
        public DateTime? FromDate = null;
        public DateTime? ToDate = null;
    }
}