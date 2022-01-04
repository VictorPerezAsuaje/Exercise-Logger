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
    public class TraineeRepository : IReadOnlyRepository<Trainee>
    {
        private readonly ExerciseLogDbContext _context;
        private readonly Status _status = new Status();

        public TraineeRepository(ExerciseLogDbContext context)
        {
            this._context = context;
        }
        public async Task<List<Trainee>> GetAll()
        {
            List<Trainee> traineeList = await _context.Trainees
                .Include(t => t.DistanceExercises)
                .ThenInclude(t => t.Exercise)
                .Include(t => t.CalistenicExercises)
                .ThenInclude(t => t.Exercise)
                .ToListAsync();

            return traineeList;
        }

        public async Task<Trainee> GetById(int id)
        {
            Trainee trainee = await _context.Trainees
                .Where(m => m.Id == id)
                .Include(t => t.DistanceExercises)
                .ThenInclude(t => t.Exercise)
                .Include(t => t.CalistenicExercises)
                .ThenInclude(t => t.Exercise)
                .FirstOrDefaultAsync();

            if (trainee == null) return null;

            return trainee;
        }

        public Trainee GetByName(string name) => _context.Trainees
                .Where(m => m.TraineeName.ToLower() == name.ToLower())
                .Include(t => t.DistanceExercises)
                .Include(t => t.CalistenicExercises)
                .FirstOrDefault();
    }
}
