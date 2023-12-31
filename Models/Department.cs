﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
    }
}
