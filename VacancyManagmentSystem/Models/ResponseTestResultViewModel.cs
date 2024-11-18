namespace VacancyManagmentSystem.Models
{
    public class ResponseTestResultViewModel
    {
        public int CorrectAnswers { get; set; }
        public int ApplicationId { get; set; }
        public int IncorrectAnswers { get; set; }
        public int UnansweredQuestions { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectPercentage { get; set; } 
    }

}
