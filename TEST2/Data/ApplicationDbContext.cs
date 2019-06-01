using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TEST2.Models;
using TEST2.Models.SubjectRepo;

namespace TEST2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        // public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Subject> Subjects { get; set; }
    }
}
