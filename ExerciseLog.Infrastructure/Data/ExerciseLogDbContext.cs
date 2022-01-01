using Microsoft.EntityFrameworkCore;
using ExerciseLog.Domain.Entities;
using System;

namespace ExerciseLog.Infrastructure.Data
{
    public class ExerciseLogDbContext : DbContext
    {
        public ExerciseLogDbContext(DbContextOptions<ExerciseLogDbContext> options) : base(options)
        {

        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Trainee> Trainees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>().HasKey(e => e.Id);
            modelBuilder.Entity<Exercise>()
                .HasOne(e => e.Trainee).WithMany(t => t.ExerciseRecord);

            modelBuilder.Entity<Trainee>().HasKey(t => t.Id);
            modelBuilder.Entity<Trainee>()
                .HasMany(e => e.ExerciseRecord).WithOne(t => t.Trainee);
        } 
    }
}
