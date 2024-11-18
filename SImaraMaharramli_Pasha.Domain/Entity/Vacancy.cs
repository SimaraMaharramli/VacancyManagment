using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImaraMaharramli_Pasha.Domain.Entity
{
    public class Vacancy
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.UtcNow;
        public ICollection<Question> Questions { get; set; }
        public List<VacancyApplication> Applications { get; set; }
        public DateTime ValidFrom { get; set; } 
        public DateTime ValidTo { get; set; }
    }
}
