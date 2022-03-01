using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_MVC.Models
{
    public class ApplicantsTable
    {
        [Key]
        public int ID { get; set;}

        [Required]
        public string Applicant_Name { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Floor cannot be greater than 10!")]
        public int Floor { get; set; }
        [Required]
        public int SSN { get; set; }
    }
}
