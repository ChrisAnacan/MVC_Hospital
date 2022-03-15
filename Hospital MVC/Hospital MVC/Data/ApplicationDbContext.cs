using Hospital_MVC.Models;
using Hospital_MVC.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) // SQL 
        {
        
        }
        public DbSet<DoctorsTable> DoctorsTable { get; set; }
        public DbSet<NursesTable> NursesTable { get; set; }
        public DbSet<CNAs> CNAs { get; set; }
        public DbSet<ApplicantsTable> ApplicantsTable { get; set; }

        
    }
}
