using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SImaraMaharramli_Pasha.Domain;
using SImaraMaharramli_Pasha.Domain.Entity;
using SImaraMaharramli_Pasha.Service.DTOS.TestResultDto;
using SImaraMaharramli_Pasha.Service.Interfaces;
using SImaraMaharramli_Pasha.Service.Services;
using VacancyManagmentSystem.Models;

namespace VacancyManagmentSystem.Controllers
{
    [Route("QusetionTest")]
    public class QusetionTestController : Controller
    {
        private readonly IVacancyApplicationService _applicationService;
        private readonly IVacancyService _vacancyService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _context;
        private readonly AppTestService _testService;


        public QusetionTestController(
            IVacancyApplicationService applicationService,
            IVacancyService vacancyService,
            IWebHostEnvironment webHostEnvironment, AppDbContext context, AppTestService testService)
        {
            _applicationService = applicationService;
            _vacancyService = vacancyService;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _testService = testService;
        }

        [HttpGet("TestRules")]
        public IActionResult TestRules(int applicationId)
        {
            var rulesViewModel = new TestRulesViewModel
            {
                ApplicationId = applicationId,
                Rules = "1. You have 1 minute per question.\n\n2. You cannot go back to previous questions.\n\n3. Skipping a question counts as incorrect."
            };

            return View(rulesViewModel);
        }

        [HttpGet("StartQuestion/{applicationId}")]
        
        public async Task<IActionResult> StartQuestion(int applicationId, int questionIndex = 0)
        {
            
            var questions = await _testService.GetQuestionsByApplicationIdAsync(applicationId);

            if (questionIndex >= questions.Count)
            {
                return RedirectToAction("TestResults", new { applicationId });
            }

            var questionViewModel = new QuestionViewModel
            {
                Question = questions[questionIndex],
                ApplicationId = applicationId,
                CurrentIndex = questionIndex,
                TotalQuestions = questions.Count
            };

            return View( questionViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SubmitAnswer(int applicationId, int questionId, int? answerId, int questionIndex)
        {
            await _testService.SaveUserAnswerAsync(applicationId, questionId, answerId);
            var totalQuestions = await _testService.GetTotalQuestionsForApplicationAsync(applicationId);

            if (questionIndex + 1 >= totalQuestions)
            {
                return RedirectToAction("TestResults", new { applicationId });
            }

            return RedirectToAction("StartQuestion", new { applicationId, questionIndex = questionIndex + 1 });
        }
        [HttpGet("TestResults/{applicationId}")]
        public async Task<IActionResult> TestResults(int applicationId)
        {
            var result = await _testService.CalculateTestResultAsync(applicationId);

            var viewModel = new ResponseTestResultViewModel
            {
                CorrectAnswers = result.CorrectAnswers,
                IncorrectAnswers = result.TotalQuestions - result.CorrectAnswers - result.UnansweredQuestions,
                UnansweredQuestions = result.UnansweredQuestions,
                TotalQuestions = result.TotalQuestions,
                CorrectPercentage = result.CorrectPercentage,
                ApplicationId = applicationId
            };

            return View(viewModel);
        }







    }
}
