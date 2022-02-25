using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // lets us use [key] , [required] etc
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_MVC.Models
{
    public class DoctorsTable
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Doctor_Name { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Floor cannot be greater than 10!")]
        public int Floor { get; set; }
        [Required]
        public int SSN { get; set; }

    }
}
