namespace StackOverflow
{
    public enum QuestionSort
    {
        [SortArgs("active")]
        Active,
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
        [SortArgs("unanswered")]
        Unanswered,
        [SortArgs("unanswered", "newest")]
        UnansweredNewest,
        [SortArgs("unanswered", "votes")]
        UnansweredVotes
    }
}