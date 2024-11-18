using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImaraMaharramli_Pasha.Service.DTOS.TestResultDto
{
    public class TestResultViewModel
    {
        public int ApplicationId { get; set; } 
        public string ApplicantName { get; set; } 
        public string VacancyTitle { get; set; }
        public int CorrectAnswers { get; set; } 
        public int TotalQuestions { get; set; } 
        public double Percentage { get; set; }
        public string ResultStatus { get; set; } 
        public DateTime TestDate { get; set; } 
    }
}
