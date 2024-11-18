using Microsoft.AspNetCore.Mvc;
using SImaraMaharramli_Pasha.Service.Interfaces;
using System.Diagnostics;
using VacancyManagmentSystem.Models;

namespace VacancyManagmentSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IVacancyService _vacancyService;
        public HomeController( IVacancyService vacancyService,ICategoryService categoryService)
        {
            _vacancyService = vacancyService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int categoryId)
        {
            ViewBag.categoryId = categoryId;
            var getallitem = new GetAllCategoryVacancy()
            {
                Vacancies = await _vacancyService.GetAll(categoryId),
                Categories = await _categoryService.GetAll(),
            };
            return View(getallitem);
        }
        public async Task<IActionResult> Detail(int Id)
        {
            var vacancy=await _vacancyService.GetDetail(Id);
            
            return View(vacancy);
        }

      

     
    }
}
