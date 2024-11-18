using System.ComponentModel.DataAnnotations;

namespace VacancyManagmentSystem.Models
{
    public class ApplicationViewModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; } 
        public int VacancyId { get; set; } 
        public string VacancyTitle { get; set; } 
    }
}
