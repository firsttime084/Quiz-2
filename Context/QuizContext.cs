using Microsoft.EntityFrameworkCore;
using Quiz.Models;
namespace Quiz.Context
{
    public class QuizContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public QuizContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>().HasData
                (

                         new Answer() { AnswerId = 1, AnswerText = "2", Iscorrect = true, questionId = 1 },
                         new Answer() { AnswerId = 2, AnswerText = "4", Iscorrect = false, questionId = 1 },
                         new Answer() { AnswerId = 3, AnswerText = "0", Iscorrect = false, questionId = 1 },
                         new Answer() { AnswerId = 4, AnswerText = "10", Iscorrect = false, questionId = 1 },

                         new Answer() { AnswerId = 5, AnswerText = "2", Iscorrect = false, questionId = 2 },
                         new Answer() { AnswerId = 6, AnswerText = "4", Iscorrect = false, questionId = 2 },
                         new Answer() { AnswerId = 7, AnswerText = "0", Iscorrect = true, questionId = 2 },
                         new Answer() { AnswerId = 8, AnswerText = "10", Iscorrect = false, questionId = 2 },

                         new Answer() { AnswerId = 9, AnswerText = "20", Iscorrect = false, questionId = 3 },
                         new Answer() { AnswerId = 10, AnswerText = "5", Iscorrect = true, questionId = 3 },
                         new Answer() { AnswerId = 11, AnswerText = "30", Iscorrect = false, questionId = 3 },
                         new Answer() { AnswerId = 12, AnswerText = "10", Iscorrect = false, questionId = 3 },

                         new Answer() { AnswerId = 13, AnswerText = "Red", Iscorrect = false, questionId = 4 },
                         new Answer() { AnswerId = 14, AnswerText = "Green", Iscorrect = true, questionId = 4 },
                         new Answer() { AnswerId = 15, AnswerText = "Blue", Iscorrect = false, questionId = 4 },
                         new Answer() { AnswerId = 16, AnswerText = "Black", Iscorrect = false, questionId = 4 },
                         new Answer() { AnswerId = 17, AnswerText = "Gray", Iscorrect = false, questionId = 4 }

                );

            modelBuilder.Entity<Question>()
                .HasData
                (

                    new Question
                    {
                        QuestionId = 1,
                        QuestionText = "What is the result of 1+1?",
                    },
                    new Question()
                    {
                        QuestionId = 2,
                        QuestionText = "What is the result of 1-1?",
                    },
                    new Question()
                    {
                        QuestionId = 3,
                        QuestionText = "What is the result of 10-5?",
                    },
                    new Question()
                    {
                        QuestionId = 4,
                        QuestionText = "What color ir grass?",
                    }
                );


        }
    }
}
