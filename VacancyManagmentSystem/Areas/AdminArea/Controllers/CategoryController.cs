using Microsoft.AspNetCore.Mvc;
using SImaraMaharramli_Pasha.Domain.Entity;
using SImaraMaharramli_Pasha.Service.Interfaces;
using SImaraMaharramli_Pasha.Service.Services;
using VacancyManagmentSystem.Controllers;

namespace VacancyManagmentSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly GenericService<Category> _service;
        public CategoryController(  ICategoryService categoryService, GenericService<Category> service)
        {
            _categoryService = categoryService;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.CurrentController = "Category";
            ViewBag.CurrentAction = "Index";
            var ctgs =await _categoryService.GetAll();
            return View(ctgs);
        }
        public IActionResult Create()
        {
            ViewBag.CurrentController = "Category";
            ViewBag.CurrentAction = "Index";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category ctg)
        {
           var result=await _service.CreateAsync(ctg);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Update( int id)
        {
            ViewBag.CurrentController = "Category";
            ViewBag.CurrentAction = "Index";
            var ctg=await _categoryService.GetDetail(id);
            return View(ctg);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Category ctg)
        {
           var result=await _service.UpdateAsync(ctg);
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
