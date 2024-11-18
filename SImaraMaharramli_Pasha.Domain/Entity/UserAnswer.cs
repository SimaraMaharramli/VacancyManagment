using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImaraMaharramli_Pasha.Domain.Entity
{
    public class UserAnswer
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public VacancyApplication Application { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int? AnswerId { get; set; }
        public Answer? Answer { get; set; }
    }
}
