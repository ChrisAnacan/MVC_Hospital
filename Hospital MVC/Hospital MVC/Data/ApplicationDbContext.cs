using Hospital_MVC.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) // SQL 
        {
        
        }
        public DbSet<DoctorsTable> DoctorsTable { get; set; }
        public DbSet<ApplicantsTable> ApplicantsTable { get; set; }
    }
}
