using Microsoft.EntityFrameworkCore;
using SImaraMaharramli_Pasha.Domain;
using SImaraMaharramli_Pasha.Domain.Entity;
using SImaraMaharramli_Pasha.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SImaraMaharramli_Pasha.Service.Services
{
    public class ApplicationService : IVacancyApplicationService
    {
        private readonly AppDbContext _context;

        public ApplicationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<VacancyApplication> ApplyAsync(VacancyApplication application)
        {
            _context.Applications.Add(application);
            var result=await _context.SaveChangesAsync();
            return application;
        }

        public async Task<VacancyApplication> GetApplicationByIdAsync(int id)
        {
            return await _context.Applications.Include(a => a.Vacancy).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UploadCvAsync(int applicationId, string cvPath)
        {
            var application = await _context.Applications.FindAsync(applicationId);
            if (application != null)
            {
                application.CVPath = cvPath;
                await _context.SaveChangesAsync();
            }
        }
    }

}
