using Microsoft.AspNetCore.Mvc;

namespace VacancyManagmentSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
