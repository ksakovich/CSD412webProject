using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CSD412webProject.Models;
using Microsoft.AspNetCore.Identity;

namespace CSD412webProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    //public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext()
            : base()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string azureDbKey = Environment.GetEnvironmentVariable("AZURE_DB_PASSWORD");
            optionsBuilder.UseSqlServer($"Server=tcp:ksakovichserver.database.windows.net,1433;Initial Catalog=Cinematoria;Persist Security Info=False;User ID=kirsak;Password={azureDbKey};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
