using Hospital_MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_MVC.Models
{
    public class NursesTable
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Floor cannot be greater than 10!")]
        public int Floor { get; set; }
        [Required(ErrorMessage = "SSN Must be of Length 9!")]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")] // @ - every char ahead. + - once it checks one character checks the rest

        public int SSN { get; set; }
        [Required]
        public DoctorsTable Assigned { get; set; }

    }
}