using SystemGestionHR.Data.Models;
using SystemGestionHR.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace SystemGestionHR.Data
{
    public class EmployeDB : DbContext
    {
        public EmployeDB(DbContextOptions<EmployeDB> options) : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<DemandeDeConge> DemandeDeConge { get; set; }
        public DbSet<TypeConge> TypeConge { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Adds configurations for Student from separate class
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new TypeCongeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeConfiguration());

        }
    }
}
