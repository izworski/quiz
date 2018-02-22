using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class Audit
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string TableName { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int KeyValue { get; set; }

        [Required]
        [MaxLength(100)]
        public string ColumnName { get; set; } 

        [Required]
        public string OldValue { get; set; }

        [Required]
        public string NewValue { get; set; }
    }
}
