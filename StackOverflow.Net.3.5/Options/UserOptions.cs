using System;

namespace StackOverflow
{
    public class UserOptions
    {
        public UserSort SortBy = UserSort.Reputation;
        public SortDirection SortDirection = SortDirection.Descending;
        public int? Page = null;
        public int? PageSize = null;
        public string Filter = null;
        public DateTime? FromDate = null;
        public DateTime? ToDate = null;
        public int? Min = null;
        public int? Max = null;
    }
}