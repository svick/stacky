namespace Stacky
{
    public enum QuestionSort
    {
        [SortArgs("activity")]
        Activity,
        [SortArgs("newest")]
        Newest,
        [SortArgs("featured")]
        Featured,
        [SortArgs("hot")]
        Hot,
        [SortArgs("week")]
        Week,
        [SortArgs("month")]
        Month,
        [SortArgs("votes")]
        Votes,
        [SortArgs(null, "unanswered")]
        Unanswered,
        [SortArgs("newest", "unanswered")]
        UnansweredNewest,
        [SortArgs("votes", "unanswered")]
        UnansweredVotes
    }
}