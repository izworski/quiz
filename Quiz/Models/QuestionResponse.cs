using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class QuestionResponse
    {
        public int Id { get; set; }

        [Required]
        public Question Question { get; set; }

        [Required]
        public Answer SelectedAnswer { get; set; }

        [Required]
        public QuizRun QuizRun { get; set; }

        [Required]
        public int TimePassed { get; set; }

        [Required]
        public int ResponseOrder { get; set; }
    }
}
