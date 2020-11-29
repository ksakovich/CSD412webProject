using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CSD412webProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace CSD412webProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<CSD412webProject.Models.User> User { get; set; }
        public DbSet<CSD412webProject.Models.Movie> Movie { get; set; }
        public DbSet<CSD412webProject.Models.MovieList> MovieList { get; set; }
        public DbSet<CSD412webProject.Models.Genre> Genre { get; set; }
        public DbSet<CSD412webProject.Models.ListOfMovieLists> ListOfMovieLists { get; set; }
    }
}
