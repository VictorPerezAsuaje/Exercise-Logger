using ExerciseLog.Domain.DTO;
using ExerciseLog.Domain.EntidadesAuxiliares;
using ExerciseLog.Domain.Entities;
using ExerciseLog.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExerciseLog.Infrastructure.Interfaces
{
    public interface IReadOnlyRepository<T> 
    {
        Task<T> GetById(int id);
        T GetByName(string name);
        Task<List<T>> GetAll();
    }
}
