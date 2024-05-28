using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.Context;
using Quiz.Models;
using System.Diagnostics;

namespace Quiz.Controllers
{
    public class HomeController : Controller
    {
        public static int QuestionIndex;
        private readonly QuizContext _context;
        public HomeController(QuizContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            ViewBag.TotalQuestions = _context.Questions.Count();

            if (id == null)
            {
                return View(_context.Questions.Include(p => p.Answers).First());
            }
            if (id.Value > _context.Questions.Count())
            {
                return View(_context.Questions.Include(p => p.Answers).Last());
            }
            QuestionIndex = id.Value;

            ViewBag.AnsweredQuestions = _context.Questions.Where(p => p.AnswerGivenIndex != 0).Count();

            var question = _context.Questions.Include(p => p.Answers).FirstOrDefault(e => e.QuestionId == QuestionIndex);
            return View(question);
        }

        [HttpPost]
        public IActionResult Answers(Question q)
        {
            ViewBag.TotalQuestions = _context.Questions.Count();
            ViewBag.AnsweredQuestions = _context.Questions.Where(p => p.AnswerGivenIndex != 0).Count();

            var AnswerUpdate = _context.Questions.FirstOrDefault(b => b.QuestionId == q.QuestionId);
            if (AnswerUpdate != null)
            {
                AnswerUpdate.AnswerGivenIndex = q.AnswerGivenIndex;
                _context.SaveChanges();
            }

            var que = _context.Questions.Include(p => p.Answers).FirstOrDefault(p => p.QuestionId == q.QuestionId);

            return View("Index", que);

            //var count = _context.Questions.Count();
            //int idd = q.QuestionId + 1;
            //if (q.QuestionId >= 1 && q,QuestionId <= count - 1)
            //{
            //	return RedirectToAction("Index", new { id = idd });
            //}
            //else if (q.QuestionId == count)
            //{
            //	return RedirectToAction("Summary");
            //}
            //return View("Index");

            //return RedirectToAction("Index", q.QuestionId);
        }

        [HttpGet]
        public IActionResult Summary()
        {
            ViewBag.TotalQuestions = _context.Questions.Count();
            ViewBag.AnsweredQuestions = _context.Questions.Where(p => p.AnswerGivenIndex != 0).Count();
            var all_questions = _context.Questions.Include(p => p.Answers).ToList();

            return View(all_questions);
        }

        [HttpGet]
        public IActionResult AddQuestion()
        {
            ViewBag.TotalQuestions = _context.Questions.Count();
            ViewBag.AnsweredQuestions = _context.Questions.Where(p => p.AnswerGivenIndex != 0).Count();
            return View();
        }

        [HttpPost]
        public IActionResult SubmitNewQuestion(Question question)
        {
            var newQuestion = new Question
            {
                QuestionText = question.QuestionText,
                Answers = new List<Answer>()
            };

            foreach (var answerForm in question.Answers)
            {
                if (!string.IsNullOrEmpty(answerForm.AnswerText))
                {
                    var newAnswer = new Answer
                    {
                        AnswerText = answerForm.AnswerText,
                        Iscorrect = answerForm.Iscorrect
                    };
                    newQuestion.Answers.Add(newAnswer);
                }
            }

            _context.Questions.Add(newQuestion);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
