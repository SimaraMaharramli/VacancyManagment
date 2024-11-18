using Microsoft.AspNetCore.Mvc;
using SImaraMaharramli_Pasha.Domain.Entity;
using SImaraMaharramli_Pasha.Service.DTOS.Vacancy;
using SImaraMaharramli_Pasha.Service.Interfaces;
using SImaraMaharramli_Pasha.Service.Services;

namespace VacancyManagmentSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class VacancyController : Controller
    {
        private readonly IVacancyService _vacancyService;
        private readonly ICategoryService _categoryService;
        private readonly GenericService<Vacancy> _service;
        public VacancyController(IVacancyService vacancyService, GenericService<Vacancy> service,ICategoryService categoryService)
        {
            _vacancyService = vacancyService;
            _service = service;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.CurrentController = "Vacancy";
            ViewBag.CurrentAction = "Index";
            int catid = 0;
            var ctgs = await _vacancyService.GetAll(catid);
            return View(ctgs);
        }
        public async Task<IActionResult> ChangeStatus(int vacancyId)
        {
            ViewBag.CurrentController = "Vacancy";
            ViewBag.CurrentAction = "Index";
            var ctg = await _vacancyService.GetVacancyByIdAsync(vacancyId);
            if (ctg.IsActive)
            {
                ctg.IsActive = false;
            }
            else 
            {
                ctg.IsActive = true;
            }

            var result = await _service.UpdateAsync(ctg);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.CurrentController = "Vacancy";
            ViewBag.CurrentAction = "Create";
            ViewBag.Categories=await _categoryService.GetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Vacancy ctg)
        {
            ctg.CreatedDate = DateTime.UtcNow;
            var result = await _service.CreateAsync(ctg);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.CurrentController = "Vacancy";
            ViewBag.CurrentAction = "Update";
            ViewBag.Categories = await _categoryService.GetAll();
            var ctg = await _vacancyService.GetDetail(id);
            return View(ctg);
        }
        [HttpPost]
        public async Task<IActionResult> Update(GetDetailVacancy ctg)
        {
            var vacancy= new Vacancy()
            {
                Id = ctg.Id,
                CategoryId = ctg.CategoryId,
                Name = ctg.Name,
                Description = ctg.Description,
                IsActive = ctg.IsActive,
                ValidTo = ctg.ValidTo,
                ValidFrom = ctg.ValidFrom,
            };
            var result = await _service.UpdateAsync(vacancy);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

