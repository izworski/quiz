using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class Question
    {
        public int Id { get; set; }

        public Category Category { get; set; }
        
        public User CreatedBy { get; set; }

        [Required]
        public QuestionDifficulty Difficulty { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        [Range(0, 300)]
        public int MaxSecondsToComplete { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public virtual ICollection<QuestionResponse> QuestionResponses { get; set; }
    }

    public enum QuestionDifficulty
    {
        Hard,
        Medium,
        Easy
    }
}
