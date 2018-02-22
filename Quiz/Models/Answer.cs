using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public Question Question { get; set; }

        public User CreatedBy { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsCorrect { get; set; }

        [Required]
        public string Value { get; set; }

        public virtual ICollection<QuestionResponse> QuestionResponses { get; set; }
    }
}
