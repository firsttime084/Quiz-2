using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Quiz.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public bool Iscorrect { get; set; }
        public int questionId { get; set; }
        public Question question { get; set; }

    }
}
