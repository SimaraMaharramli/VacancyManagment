using Microsoft.EntityFrameworkCore;
using SImaraMaharramli_Pasha.Domain;
using SImaraMaharramli_Pasha.Domain.Entity;
using SImaraMaharramli_Pasha.Service.DTOS.Category;
using SImaraMaharramli_Pasha.Service.DTOS.Vacancy;
using SImaraMaharramli_Pasha.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImaraMaharramli_Pasha.Service.Services
{
    public class VacancyService:IVacancyService
    {
        private readonly AppDbContext _context;
        //private readonly IMapper _mapper;

        public VacancyService(AppDbContext context /*IMapper mapper*/)
        {
            _context = context;
            //_mapper = mapper;
        }
        public async Task<Vacancy> GetVacancyByIdAsync(int id)
        {
            return await _context.Vacancies.Include(v => v.Questions).FirstOrDefaultAsync(v => v.Id == id);
        }
        public async Task<List<GetAllVacancy>> GetAll(int categoryId)
        {
            var vacancies = await _context.Vacancies.Select(x => new GetAllVacancy()
            {
                Id = x.Id,
                IsActive = x.IsActive,
                Name = x.Name,
                Created=x.CreatedDate,
                CategoryId = x.CategoryId,
                ValidFrom = x.ValidFrom,
                ValidTo = x.ValidTo,
            }).OrderByDescending(x => x.Created).ToListAsync();
            if (categoryId !=0)
            {
                vacancies = vacancies.Where(x => x.CategoryId == categoryId).ToList();
            }
            return vacancies;
        }

        public async Task<GetDetailVacancy> GetDetail(int Id)
        {
            var category = await _context.Vacancies.Include(x=>x.Applications).Select(x => new GetDetailVacancy()
            {
                Id = x.Id,
                Name = x.Name,
                Description=x.Description,
                Created=x.CreatedDate,
                ValidFrom=x.ValidFrom,
                ValidTo=x.ValidTo,
                ApplicatioCount=x.Applications.Count,

            }).FirstOrDefaultAsync(x=>x.Id==Id);
            return category;
        }
    }
}
