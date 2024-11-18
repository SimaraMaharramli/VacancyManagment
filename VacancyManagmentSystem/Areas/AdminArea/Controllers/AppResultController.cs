using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SImaraMaharramli_Pasha.Domain;
using VacancyManagmentSystem.Areas.AdminArea.Models;

namespace VacancyManagmentSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class AppResultController : Controller
    {
        private readonly AppDbContext _context;

        public AppResultController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> AppList()
        {
            ViewBag.CurrentController = "AppResult";
            ViewBag.CurrentAction = "AppList";
            var applicationres= await _context.Applications.Include(x=>x.AppTestResult).ToListAsync();
            return View(applicationres);
        }

        [HttpGet]
        public async Task<IActionResult> TestResultsDetails(int applicationId)
        {
            ViewBag.CurrentController = "AppResult";
            ViewBag.CurrentAction = "AppList";
            // Adayın cevaplarını ve soruları al
            var userAnswers = await _context.UserAnswers
                .Include(ua => ua.Question)
                .ThenInclude(q => q.Answers) // Sorunun tüm cevaplarını al
                .Include(ua => ua.Answer)   // Adayın seçtiği cevabı al
                .Where(ua => ua.ApplicationId == applicationId)
                .ToListAsync();

            if (!userAnswers.Any())
            {
                return NotFound("No answers found for this application.");
            }

            // Her soruya göre detaylı sonuçları ViewModel'e hazırlayın
            var detailedResults = userAnswers.Select(ua => new DetailedResultViewModel
            {
                QuestionText = ua.Question.Text,
                SelectedAnswer = ua.Answer?.Text ?? "Not answered",
                IsCorrect = ua.Answer?.IsCorrect ?? false,
                AllAnswers = ua.Question.Answers.Select(a => new AnswerViewModel
                {
                    Text = a.Text,
                    IsCorrect = a.IsCorrect
                }).ToList()
            }).ToList();

            return View(detailedResults);
        }

    }
}
