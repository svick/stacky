using System;

namespace Stacky
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

    public class UserMentionsOptions
    {
        public UserMentionSort SortBy = UserMentionSort.Creation;
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