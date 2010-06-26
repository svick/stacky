using System;

namespace Stacky
{
    public class AnswerOptions
    {
        public AnswerSort SortBy = AnswerSort.Creation;
        public SortDirection SortDirection = SortDirection.Descending;
        public int? Page = null;
        public int? PageSize = null;
        public bool IncludeBody = false;
        public bool IncludeComments = false;
        public DateTime? FromDate = null;
        public DateTime? ToDate = null;
        public int? Min = null;
        public int? Max = null;
    }
}