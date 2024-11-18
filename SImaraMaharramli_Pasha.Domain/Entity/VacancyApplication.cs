using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImaraMaharramli_Pasha.Domain.Entity
{
    public class VacancyApplication
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
        public AppTestResult AppTestResult { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string? CVPath { get; set; }
    }
}
