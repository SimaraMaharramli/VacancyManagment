using SImaraMaharramli_Pasha.Domain.Entity;

namespace VacancyManagmentSystem.Models
{
    public class QuestionViewModel
    {
        public int ApplicationId { get; set; } 
        public Question Question { get; set; } 
        public int CurrentIndex { get; set; } 
        public int TotalQuestions { get; set; } // Toplam soru sayısı
        public int TimeLimit { get; set; } = 60;
    }
}
