using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImaraMaharramli_Pasha.Domain.Entity
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; } 
        public int VacancyId { get; set; } 
        public Vacancy Vacancy { get; set; } 
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
