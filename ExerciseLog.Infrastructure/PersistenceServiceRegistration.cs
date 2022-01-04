using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ExerciseLog.Infrastructure.Data;
using ExerciseLog.Infrastructure.Interfaces;
using ExerciseLog.Infrastructure.Repositories;
using ExerciseLog.Domain.Entities;

namespace ExerciseLog.Infrastructure
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ExerciseLogDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IExerciseRepository<DistanceExercise>, DistanceExerciseRepository>();
            services.AddScoped<IExerciseRepository<CalisthenicExercise>, CalisthenicExerciseRepository>();
            services.AddScoped<IReadOnlyRepository<Exercise>, ExerciseRepository>();
            services.AddScoped<IReadOnlyRepository<Trainee>, TraineeRepository>();

            return services;
        }
    }
}
