namespace Stacky
{
    public class QuestionByUserOptions : QuestionsOptionBase<QuestionsByUserSort>
    {
        public QuestionByUserOptions()
            : base(QuestionsByUserSort.Creation)
        {
        }
    }
}