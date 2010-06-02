namespace StackOverflow
{
    public class FavoriteQuestionOptions : QuestionsOptionBase<FavoriteQuestionsSort>
    {
        public FavoriteQuestionOptions()
            : base(FavoriteQuestionsSort.Activity)
        {
        }
    }
}