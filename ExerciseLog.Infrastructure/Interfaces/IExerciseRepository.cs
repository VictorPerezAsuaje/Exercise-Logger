using ExerciseLog.Domain.DTO;
using ExerciseLog.Domain.EntidadesAuxiliares;
using ExerciseLog.Domain.Entities;
using ExerciseLog.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExerciseLog.Infrastructure.Interfaces
{
    public interface IExerciseRepository<T> 
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task<Status> DeleteAsync(int id);
        Status Add(T entity);
        Status Update(T entity);
    }
}
