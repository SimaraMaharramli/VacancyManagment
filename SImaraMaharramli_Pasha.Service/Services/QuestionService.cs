using SImaraMaharramli_Pasha.Domain.Entity;
using SImaraMaharramli_Pasha.Domain;
using SImaraMaharramli_Pasha.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SImaraMaharramli_Pasha.Service.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly AppDbContext _context;

        public QuestionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetQuestionsByVacancyIdAsync(int vacancyId)
        {
            return await _context.Questions
                .Where(q => q.VacancyId == vacancyId)
                .Include(q => q.Answers)
                .ToListAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(int id)
        {
            return await _context.Questions.Include(q => q.Answers).FirstOrDefaultAsync(q => q.Id == id);
        }

      
    }

}
