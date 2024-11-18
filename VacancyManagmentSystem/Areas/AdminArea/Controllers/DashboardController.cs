using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SImaraMaharramli_Pasha.Domain;

namespace VacancyManagmentSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.CurrentArea = "AdminArea";
            ViewBag.CurrentController = "Dashboard";
            ViewBag.CurrentAction = "Index";
            // En çok iş ilanı olan kategori
            var mostJobCategory = await _context.Categories
                .Include(c => c.Vacancies)
                .Select(c => new MostJobCategory
                {
                    CategoryName = c.Name,
                    JobCount = c.Vacancies.Count
                })
                .OrderByDescending(c => c.JobCount)
                .FirstOrDefaultAsync();

            var mostAppliedVacancy = await _context.Vacancies
                .Include(v => v.Applications)
                .Select(v => new MostAppliedVacancy
                {
                    VacancyName = v.Name,
                    ApplicationCount = v.Applications.Count
                })
                .OrderByDescending(v => v.ApplicationCount)
                .FirstOrDefaultAsync();

            // Dashboard ViewModel'ine veri atama
            var dashboardViewModel = new DashboardViewModel
            {
                MostJobCategory = mostJobCategory,
                MostAppliedVacancy = mostAppliedVacancy
            };

            return View(dashboardViewModel);
        }
    }

    public class DashboardViewModel
    {
        public MostJobCategory MostJobCategory { get; set; }
        public MostAppliedVacancy MostAppliedVacancy { get; set; }
    }

    public class MostJobCategory
    {
        public string CategoryName { get; set; }
        public int JobCount { get; set; }
    }

    public class MostAppliedVacancy
    {
        public string VacancyName { get; set; }
        public int ApplicationCount { get; set; }
    }
}
