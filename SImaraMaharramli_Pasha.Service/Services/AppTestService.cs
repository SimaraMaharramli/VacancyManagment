using Microsoft.EntityFrameworkCore;
using SImaraMaharramli_Pasha.Domain;
using SImaraMaharramli_Pasha.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImaraMaharramli_Pasha.Service.Services
{
    public class AppTestService
    {
        private readonly AppDbContext _context;
        //private readonly IMapper _mapper;

        public AppTestService(AppDbContext context /*IMapper mapper*/)
        {
            _context = context;
            //_mapper = mapper;
        }
        public async Task<List<Question>> GetQuestionsByApplicationIdAsync(int applicationId)
        {
            var application = await _context.Applications
                .Include(a => a.Vacancy)
                .ThenInclude(v => v.Questions).ThenInclude(x=>x.Answers)
                .FirstOrDefaultAsync(a => a.Id == applicationId);

            return application?.Vacancy?.Questions.ToList() ?? new List<Question>();
        }

        public async Task SaveUserAnswerAsync(int applicationId, int questionId, int? answerId)
        {
            var userAnswer = new UserAnswer
            {
                ApplicationId = applicationId,
                QuestionId = questionId,
                AnswerId = answerId
            };

            _context.UserAnswers.Add(userAnswer);
            await _context.SaveChangesAsync();
        }




        public async Task<AppTestResult> CalculateTestResultAsync(int applicationId)
        {
            // Kullanıcı cevaplarını ve soruları al
            var userAnswers = await _context.UserAnswers
                .Include(ua => ua.Answer)
                .Where(ua => ua.ApplicationId == applicationId)
                .ToListAsync();
            var applicationre = await _context.Applications.FirstOrDefaultAsync(x => x.Id == applicationId);
            var vacancy = await _context.Vacancies.Include(x => x.Questions).FirstOrDefaultAsync(x => x.Id == applicationre.VacancyId);
            var questioncount=vacancy.Questions.Count();
            //var totalQuestions = await _context.Questions
            //    .Where(q => q.VacancyId == userAnswers.FirstOrDefault().Application.VacancyId)
            //    .CountAsync();

            var correctAnswers = userAnswers.Count(ua => ua.Answer != null && ua.Answer.IsCorrect);
            var unansweredQuestions =   userAnswers.Count(ua => ua.Answer == null);
            var incorrectAnswers =questioncount- (correctAnswers+unansweredQuestions);

            // Test sonucu oluştur
            var testResult = new AppTestResult
            {
                Application= applicationre,
                ApplicationId = applicationId,
                CorrectAnswers = correctAnswers,
                IncorrectAnswers=incorrectAnswers,
                UnansweredQuestions=unansweredQuestions,
                TotalQuestions = questioncount,
                CorrectPercentage= (questioncount > 0)
                    ? (correctAnswers * 100 / questioncount)
                    : 0,
                TestDate = DateTime.UtcNow
            };

            _context.TestResults.Add(testResult);
            await _context.SaveChangesAsync();

            // ViewModel'e detaylar için ek bilgiler döndürülür
            return new AppTestResult
            {
                ApplicationId = applicationId,
                CorrectAnswers = correctAnswers,
                TotalQuestions = questioncount,
                TestDate = DateTime.UtcNow,
                IncorrectAnswers = incorrectAnswers,
                UnansweredQuestions = unansweredQuestions
            };
        }
        public async Task<int> GetTotalQuestionsForApplicationAsync(int applicationId)
        {
            var application = await _context.Applications
                .Include(a => a.Vacancy)
                .FirstOrDefaultAsync(a => a.Id == applicationId);

            if (application == null)
                throw new Exception("Application not found.");

            // İlgili Vacancy'ye ait toplam soru sayısını alın
            return await _context.Questions
                .Where(q => q.VacancyId == application.VacancyId)
                .CountAsync();
        }


    }
}
