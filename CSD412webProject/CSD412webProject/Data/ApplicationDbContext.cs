using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CSD412webProject.Models;

namespace CSD412webProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CSD412webProject.Models.User> User { get; set; }
        public DbSet<CSD412webProject.Models.Movie> Movie { get; set; }
        public DbSet<CSD412webProject.Models.MovieList> MovieList { get; set; }
        public DbSet<CSD412webProject.Models.Genre> Genre { get; set; }
    }
}
