using Microsoft.EntityFrameworkCore;
using ExerciseLog.Domain.Entities;
using System;
using ExerciseLog.Domain.EntidadesAuxiliares;

namespace ExerciseLog.Infrastructure.Data
{
    public class ExerciseLogDbContext : DbContext
    {
        public ExerciseLogDbContext(DbContextOptions<ExerciseLogDbContext> options) : base(options)
        {

        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<CalisthenicExercise> CalisthenicExercises { get; set; }
        public DbSet<DistanceExercise> DistanceExercises { get; set; }
        public DbSet<Trainee> Trainees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>().HasKey(e => e.Id);

            modelBuilder.Entity<CalisthenicExercise>().HasKey(ce => ce.Id);
            modelBuilder.Entity<CalisthenicExercise>()
                .HasOne(ce => ce.Trainee).WithMany(t => t.CalistenicExercises);

            modelBuilder.Entity<DistanceExercise>().HasKey(de => de.Id);
            modelBuilder.Entity<DistanceExercise>()
                .HasOne(de => de.Trainee).WithMany(t => t.DistanceExercises);

            modelBuilder.Entity<Trainee>().HasKey(t => t.Id);
            modelBuilder.Entity<Trainee>()
                .HasMany(e => e.CalistenicExercises).WithOne(t => t.Trainee);
            modelBuilder.Entity<Trainee>()
                .HasMany(e => e.DistanceExercises).WithOne(t => t.Trainee);
        } 
    }
}
