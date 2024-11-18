
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
using SImaraMaharramli_Pasha.Domain;
using SImaraMaharramli_Pasha.Domain.Entity;
using SImaraMaharramli_Pasha.Service.Helpers;
using SImaraMaharramli_Pasha.Service.Interfaces;
    using SImaraMaharramli_Pasha.Service.Services;
    using VacancyManagmentSystem.Models;
    using static System.Net.Mime.MediaTypeNames;
namespace VacancyManagmentSystem.Areas.AdminArea.Controllers
{
    [Route("VacancyApplication")]
    public class VacancyApplicationController : Controller
    {
        private readonly IVacancyApplicationService _applicationService;
        private readonly IVacancyService _vacancyService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _context;
        private readonly AppTestService _testService;


        public VacancyApplicationController(
            IVacancyApplicationService applicationService,
            IVacancyService vacancyService,
            IWebHostEnvironment webHostEnvironment, AppDbContext context, AppTestService testService)
        {
            _applicationService = applicationService;
            _vacancyService = vacancyService;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _testService = testService;
        }

        [HttpGet]
        public async Task<IActionResult> Apply(int vacancyId)
        {
            var vacancy = await _vacancyService.GetVacancyByIdAsync(vacancyId);
            if (vacancy == null)
            {
                return NotFound("Vacancy not found.");
            }

            var model = new ApplicationViewModel
            {
                VacancyId = vacancy.Id,
                VacancyTitle = vacancy.Name
            };

            return View(model);
        }

        [HttpPost("Apply")]
        public async Task<IActionResult> Apply(ApplicationViewModel model)
        {
            var vacancy = await _vacancyService.GetVacancyByIdAsync(model.VacancyId);
            var applications = await _context.Applications.FirstOrDefaultAsync(x => x.Phone == model.Phone);
            if (applications != null)
            {
                return Json(new
                {
                    success = false,
                    applicationId = applications.Id,
                    message = "Application is is already exist!"
                });
            }
            var application = new VacancyApplication
            {
                FullName = model.FullName,
                Email = model.Email,
                Phone = model.Phone,
                VacancyId = model.VacancyId,
                Vacancy = vacancy,
                ApplicationDate = DateTime.UtcNow
            };

            var createdApplication = await _applicationService.ApplyAsync(application);

            // Test sürecine yönlendirme
            return Json(new
            {
                success = true,
                applicationId = createdApplication.Id,
                message = "Application submitted successfully!"
            });
        }




     


        [HttpPost]
        public async Task<IActionResult> UploadCv(IFormFile cvFile, int applicationId)
        {
            if (cvFile == null || cvFile.Length == 0)
            {
                return BadRequest("Invalid file.");
            }

            if (cvFile.ContentType != "application/pdf" && cvFile.ContentType != "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
            {
                return BadRequest("Only PDF or DOCX files are allowed.");
            }

            if (cvFile.Length > 5 * 1024 * 1024) // 5 MB sınırı
            {
                return BadRequest("File size exceeds the limit (5 MB).");
            }

                string fileName = Guid.NewGuid().ToString() + "_" + cvFile.FileName;
                string path = FileHelper.GetFilePath(_webHostEnvironment.WebRootPath, "Uploads/", fileName);
                await FileHelper.SaveFileAsync(path, cvFile);

                
          




            await _applicationService.UploadCvAsync(applicationId, $"/Uploads/{fileName}");

            return Json(new { success = true });
        }

        



        
       
    }

}
