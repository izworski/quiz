using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class Category
    {

        public int Id { get; set; }

        public Category Parent { get; set; }

        public virtual ICollection<Category> Children { get; set; }


        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public User CreatedBy { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
