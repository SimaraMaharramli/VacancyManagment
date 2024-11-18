using SImaraMaharramli_Pasha.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SImaraMaharramli_Pasha.Service.Interfaces
{
    public interface IVacancyApplicationService
    {
        Task<VacancyApplication> ApplyAsync(VacancyApplication application);
        Task<VacancyApplication> GetApplicationByIdAsync(int id);
        Task UploadCvAsync(int applicationId, string cvPath);
    }
}
