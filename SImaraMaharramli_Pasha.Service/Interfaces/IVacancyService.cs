using SImaraMaharramli_Pasha.Domain.Entity;
using SImaraMaharramli_Pasha.Service.DTOS.Category;
using SImaraMaharramli_Pasha.Service.DTOS.Vacancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImaraMaharramli_Pasha.Service.Interfaces
{
    public interface IVacancyService
    {
        Task<List<GetAllVacancy>> GetAll(int categoryId);
        Task<GetDetailVacancy> GetDetail(int Id);
        Task<Vacancy> GetVacancyByIdAsync(int id);
    }
}
