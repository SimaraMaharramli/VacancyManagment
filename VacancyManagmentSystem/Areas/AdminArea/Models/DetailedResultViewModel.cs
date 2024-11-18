namespace VacancyManagmentSystem.Areas.AdminArea.Models
{
    public class DetailedResultViewModel
    {
        public string QuestionText { get; set; }
        public string SelectedAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public List<AnswerViewModel> AllAnswers { get; set; }
    }
}
