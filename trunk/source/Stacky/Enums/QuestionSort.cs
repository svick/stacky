namespace Stacky
{
    /// <summary>
    /// Specifies the sort order for questions.
    /// </summary>
    /// activity (default), votes, creation, featured, hot, week, or month
    public enum QuestionSort
    {
        /// <summary>
        /// Activity.
        /// </summary>
        [SortArgs("activity")]
        Activity,
        /// <summary>
        /// Newest.
        /// </summary>
        [SortArgs("creation")]
        Creation,
        /// <summary>
        /// Featured.
        /// </summary>
        [SortArgs("featured")]
        Featured,
        /// <summary>
        /// Hot.
        /// </summary>
        [SortArgs("hot")]
        Hot,
        /// <summary>
        /// Week.
        /// </summary>
        [SortArgs("week")]
        Week,
        /// <summary>
        /// Month.
        /// </summary>
        [SortArgs("month")]
        Month,
        /// <summary>
        /// Vote count.
        /// </summary>
        [SortArgs("votes")]
        Votes,
        /// <summary>
        /// Unanswered.
        /// </summary>
        [SortArgs(null, "unanswered")]
        Unanswered,
        /// <summary>
        /// Newest unanswered.
        /// </summary>
        [SortArgs("creation", "unanswered")]
        UnansweredCreation,
        /// <summary>
        /// Unanswered vote count.
        /// </summary>
        [SortArgs("votes", "unanswered")]
        UnansweredVotes
    }
}