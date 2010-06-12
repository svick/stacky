using System.Collections.Generic;

namespace Stacky
{
    public class QuestionSearchOptions
    {
        public string InTitle = null;
        public IEnumerable<string> Tagged = null;
        public IEnumerable<string> NotTagged = null;
        public SearchSort SortBy = SearchSort.Activity;
        public SortDirection SortDirection = SortDirection.Descending;
        public int? Page = null;
        public int? PageSize = null;
        public int? Min = null;
        public int? Max = null;
    }
}