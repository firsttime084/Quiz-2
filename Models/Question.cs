using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        public string QuestionText { get; set; }
        public List<Answer> Answers { get; set; }

        public int AnswerGivenIndex { get; set; }
    }
}
