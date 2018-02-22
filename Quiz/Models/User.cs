using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class User
    {
        
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }


        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Login { get; set; }

        [Required]
        public AccessLevel AccessLevel { get; set; }

        public virtual ICollection<Category> CreatedCategories { get; set; }
        public virtual ICollection<Question> CreatedQuestions { get; set; }
        public virtual ICollection<QuizRun> QuizRuns { get; set; }
        public virtual ICollection<Answer> CreatedAnswers { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }

    public enum AccessLevel
    {
        Admin,
        Mentor,
        Student,
    }
}
