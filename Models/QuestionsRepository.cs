namespace Quiz.Models
{
    public static class QuestionsRepository
    {
        public static Answer GetSelectedAnswer(this Question question)
        {
            return question.Answers.FirstOrDefault(a => a.AnswerId == question.AnswerGivenIndex);
        }
    }
}