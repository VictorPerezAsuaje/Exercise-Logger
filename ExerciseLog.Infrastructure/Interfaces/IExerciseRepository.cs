using ExerciseLog.Domain.DTO;
using ExerciseLog.Domain.EntidadesAuxiliares;
using ExerciseLog.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExerciseLog.Infrastructure.Interfaces
{
    public interface IExerciseRepository
    {
        Task<Exercise> GetById(int id);
        Task<List<Exercise>> GetAll();
        Task<Status> DeleteAsync(int id);
        Status Add(Exercise entity);
        Status Update(Exercise entity);
    }
}
