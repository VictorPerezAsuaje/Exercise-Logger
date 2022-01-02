using ExerciseLog.Domain.DTO;
using ExerciseLog.Domain.EntidadesAuxiliares;
using ExerciseLog.Domain.Entities;
using ExerciseLog.Infrastructure.Data;
using ExerciseLog.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLog.Infrastructure.Repositories
{
    public class ExerciseRepository : IReadOnlyExerciseRepository<Exercise>
    {
        private readonly ExerciseLogDbContext _context;
        private readonly Status _status = new Status();

        public ExerciseRepository(ExerciseLogDbContext context)
        {
            this._context = context;
        }
        public async Task<List<Exercise>> GetAll()
        {
            List<Exercise> exerciseList = await _context.Exercises.ToListAsync();

            return exerciseList;
        }

        public async Task<Exercise> GetById(int id)
        {
            Exercise exercise = await _context.Exercises
                .Where(m => m.Id == id).FirstOrDefaultAsync();

            if (exercise == null) return null;

            return exercise;
        }

        public async Task<IEnumerable<Exercise>> GetByName(string name)
        {

            List<Exercise> exercise = await _context.Exercises
                .Where(m => m.Name.ToLower() == name.ToLower() || m.Name.ToLower().Contains(name))
                .ToListAsync();

            return exercise;
        }
    }
}
