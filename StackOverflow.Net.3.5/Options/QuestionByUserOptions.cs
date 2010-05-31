namespace StackOverflow
{
    public class QuestionByUserOptions : QuestionsOptionBase<QuestionsByUserSort>
    {
        public QuestionByUserOptions()
            : base(QuestionsByUserSort.Creation)
        {
        }
    }
}