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
    public class DistanceExerciseRepository : IExerciseRepository<DistanceExercise>
    {
        private readonly ExerciseLogDbContext _context;
        private readonly Status _status = new Status();

        public DistanceExerciseRepository(ExerciseLogDbContext context)
        {
            this._context = context;
        }

        public Status Add(DistanceExercise exercise)
        {
            if (exercise == null) 
                return _status.ResultWas(StatusResult.Error).WithMessage("Exercise can not be null.");

            Trainee Trainee = _context.Trainees.Find(exercise.TraineeId);
            if(Trainee == null)
                return _status.ResultWas(StatusResult.Error).WithMessage("There's no Trainee with that ID.");

            exercise.Trainee = Trainee;
            _context.DistanceExercises.Add(exercise);

            if (_context.SaveChanges() < 1)
                return _status.ResultWas(StatusResult.Error).WithMessage("It was not inserted properly.");

            return _status.ResultWas(StatusResult.Correct);
        }

        public async Task<Status> DeleteAsync(int id)
        {
            if(id < 1)
                return _status.ResultWas(StatusResult.Error).WithMessage("Id can not be less than 1.");

            DistanceExercise Exercise = await _context.DistanceExercises.FindAsync(id);
            _context.DistanceExercises.Remove(Exercise);

            if (_context.SaveChanges() < 1)
                return _status.ResultWas(StatusResult.Error).WithMessage("It was not deleted properly.");

            return _status.ResultWas(StatusResult.Correct);
        }

        public async Task<List<DistanceExercise>> GetAll()
        {
            List<DistanceExercise> exerciseList = await _context.DistanceExercises.Include(m => m.Exercise).Include(m => m.Trainee)?.ToListAsync();

            return exerciseList;
        }

        public async Task<DistanceExercise> GetById(int id)
        {

            DistanceExercise exerciseItem = await _context.DistanceExercises
                .Include(m => m.Exercise)
                .Include(m => m.Trainee)
                .Where(m => m.Id == id).FirstOrDefaultAsync();

            if (exerciseItem == null) return null;

            return exerciseItem;
        }

        public Status Update(DistanceExercise entity)
        {
            if (entity == null)
                return _status.ResultWas(StatusResult.Error).WithMessage("Exercise can not be null.");

            _context.DistanceExercises.Update(entity);

            if (_context.SaveChanges() < 1)
                return _status.ResultWas(StatusResult.Error).WithMessage("It was not updated properly.");

            return _status.ResultWas(StatusResult.Correct);
        }
    }
}
