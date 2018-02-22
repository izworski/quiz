using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class QuizRun
    {
        public int Id { get; set; }

        public User Participant { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public virtual ICollection<QuestionResponse> QuestionResponses { get; set; }
    }
}
