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
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ExerciseLogDbContext _context;
        private readonly Status _status = new Status();

        public ExerciseRepository(ExerciseLogDbContext context)
        {
            this._context = context;
        }

        public Status Add(Exercise exercise)
        {
            if (exercise == null) 
                return _status.ResultWas(StatusResult.Error).WithMessage("Exercise can not be null.");

            Trainee Trainee = _context.Trainees.Find(exercise.TraineeId);
            if(Trainee == null)
                return _status.ResultWas(StatusResult.Error).WithMessage("There's no Trainee with that ID.");

            exercise.Trainee = Trainee;
            _context.Exercises.Add(exercise);

            if (_context.SaveChanges() < 1)
                return _status.ResultWas(StatusResult.Error).WithMessage("It was not inserted properly.");

            return _status.ResultWas(StatusResult.Correct);
        }

        public async Task<Status> DeleteAsync(int id)
        {
            if(id < 1)
                return _status.ResultWas(StatusResult.Error).WithMessage("Id can not be less than 1.");

            Exercise Exercise = await _context.Exercises.FindAsync(id);
            _context.Exercises.Remove(Exercise);

            if (_context.SaveChanges() < 1)
                return _status.ResultWas(StatusResult.Error).WithMessage("It was not deleted properly.");

            return _status.ResultWas(StatusResult.Correct);
        }

        public async Task<List<Exercise>> GetAll()
        {
            List<Exercise> exerciseList = await _context.Exercises.Include(m => m.Trainee)?.ToListAsync();

            return exerciseList;
        }

        public async Task<Exercise> GetById(int id)
        {

            Exercise exerciseItem = await _context.Exercises
                            .Include(m => m.Trainee)
                            .Where(m => m.Id == id).FirstOrDefaultAsync();

            if (exerciseItem == null) return null;

            return exerciseItem;
        }

        public Status Update(Exercise entity)
        {
            if (entity == null)
                return _status.ResultWas(StatusResult.Error).WithMessage("Exercise can not be null.");

            _context.Exercises.Update(entity);

            if (_context.SaveChanges() < 1)
                return _status.ResultWas(StatusResult.Error).WithMessage("It was not updated properly.");

            return _status.ResultWas(StatusResult.Correct);
        }
    }
}
