using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SImaraMaharramli_Pasha.Domain.Entity
{
    public class AppTestResult
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; } 
        public VacancyApplication Application { get; set; } 
        public int CorrectAnswers { get; set; } 
        public int TotalQuestions { get; set; } 
        public int IncorrectAnswers { get; set; } 
        public int UnansweredQuestions { get; set; }
        public int CorrectPercentage { get; set; }
        public DateTime TestDate { get; set; } 
    }
}
