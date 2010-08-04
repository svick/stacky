using System;

namespace Stacky
{
    public abstract class QuestionsOptionBase<T>
    {
        public QuestionsOptionBase(T defaultSort)
        {
            SortBy = defaultSort;
        }

        public T SortBy;
        public SortDirection SortDirection = SortDirection.Descending;
        public int? Page = null;
        public int? PageSize = null;
        public bool IncludeBody = false;
        public bool IncludeComments = false;
        public bool IncludeAnswers = false;
        public DateTime? FromDate = null;
        public DateTime? ToDate = null;
        public string[] Tags = null;
        public int? Min = null;
        public int? Max = null;
    }
}