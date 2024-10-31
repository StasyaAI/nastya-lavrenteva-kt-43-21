using _1_лабораторная.Database.Configurations;
using _1_лабораторная.Models;
using Microsoft.EntityFrameworkCore;

namespace _1_лабораторная.Database
{
    public class TeacherDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
        }

        public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options)
        {

        }
    }
}
