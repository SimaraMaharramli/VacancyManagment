using SImaraMaharramli_Pasha.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImaraMaharramli_Pasha.Service.Interfaces
{
    public interface IQuestionService
    {
        Task<List<Question>> GetQuestionsByVacancyIdAsync(int vacancyId);
        Task<Question> GetQuestionByIdAsync(int id);
    }
}
