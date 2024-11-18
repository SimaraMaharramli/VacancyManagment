using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SImaraMaharramli_Pasha.Domain;
using SImaraMaharramli_Pasha.Domain.Entity;

namespace VacancyManagmentSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class QuestionController : Controller
    {
        private readonly AppDbContext _context;

        public QuestionController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.CurrentController = " Question";
            ViewBag.CurrentAction = "Index";
            var vacancies = await _context.Vacancies
                .Include(v => v.Questions)
                .ThenInclude(q => q.Answers).Take(5)
                .ToListAsync();

            return View(vacancies);
        }
        [HttpGet]
        public async Task<IActionResult> AllQuestion(int vacancyId)
        {
            ViewBag.CurrentController = " Question";
            ViewBag.CurrentAction = "AllQuestion";
            var vacancies = await _context.Questions.Where(x=>x.VacancyId==vacancyId)
                .Include(q => q.Answers)
                .ToListAsync();

            return View(vacancies);
        }

        [HttpGet]
        public IActionResult Create(int vacancyId)
        {
            ViewBag.CurrentController = " Question";
            ViewBag.CurrentAction = "Create";
            var model = new Question
            {
                VacancyId = vacancyId,
                Answers = new List<Answer>
                {
                    new Answer(),
                    new Answer(),
                    new Answer(),
                }
            };

            ViewBag.Vacancies = _context.Vacancies.FirstOrDefault(x=>x.Id==vacancyId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Question model, int CorrectAnswer)
        {
           
                var answerList = model.Answers.ToList();

                for (int i = 0; i < answerList.Count; i++)
                {
                    
                    answerList[i].IsCorrect = (i == CorrectAnswer);
                }
                model.Answers = answerList;
                _context.Questions.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("AllQuestion"  , new { vacancyId = model.VacancyId });
            
        }



        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.CurrentController = " Question";
            ViewBag.CurrentAction = "Update";
            ViewBag.Vacancies = _context.Vacancies.ToList();
            var question = await _context.Questions
                .Include(q => q.Answers)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Question model, int? CorrectAnswer)
        {

            var question = await _context.Questions
                .Include(q => q.Answers)
                .FirstOrDefaultAsync(q => q.Id == model.Id);

            if (question == null)
            {
                return NotFound();
            }

            question.Text = model.Text;
            question.VacancyId = model.VacancyId;


            for (int i = 0; i < question.Answers.Count; i++)
            {
                question.Answers[i].Text = model.Answers[i].Text;
                question.Answers[i].IsCorrect = (i == CorrectAnswer);
            }

            _context.Questions.Update(question);
            await _context.SaveChangesAsync();

            return RedirectToAction("AllQuestion", new { vacancyId = model.VacancyId });

        }

       
        public async Task<IActionResult> Delete(int id)
        {
            var question = await _context.Questions
                .Include(q => q.Answers) 
                .FirstOrDefaultAsync(q => q.Id == id);

            if (question == null)
            {
                return NotFound("Question not found.");
            }

            _context.Answers.RemoveRange(question.Answers);
            _context.Questions.Remove(question);

            await _context.SaveChangesAsync(); 

            return RedirectToAction("Index"); 
        }
    }
}
