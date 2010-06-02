namespace StackOverflow
{
    public class QuestionOptions : QuestionsOptionBase<QuestionSort>
    {
        public QuestionOptions()
            : base(QuestionSort.Active)
        {
        }
    }
}