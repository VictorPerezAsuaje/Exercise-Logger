using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ExerciseLog.Infrastructure.Data;
using ExerciseLog.Infrastructure.Interfaces;
using ExerciseLog.Infrastructure.Repositories;

namespace ExerciseLog.Infrastructure
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ExerciseLogDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IExerciseRepository, ExerciseRepository>();

            return services;
        }
    }
}
