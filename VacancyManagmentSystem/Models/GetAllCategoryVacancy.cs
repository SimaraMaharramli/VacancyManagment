using SImaraMaharramli_Pasha.Service.DTOS.Category;
using SImaraMaharramli_Pasha.Service.DTOS.Vacancy;

namespace VacancyManagmentSystem.Models
{
    public class GetAllCategoryVacancy
    {
        public List<GetAllCategory> Categories { get; set; }
        public List<GetAllVacancy> Vacancies { get; set; }
    }
}
