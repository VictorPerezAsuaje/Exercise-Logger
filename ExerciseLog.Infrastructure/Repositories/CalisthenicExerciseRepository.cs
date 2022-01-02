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
    public class CalisthenicExerciseRepository : IExerciseRepository<CalisthenicExercise>
    {
        private readonly ExerciseLogDbContext _context;
        private readonly Status _status = new Status();

        public CalisthenicExerciseRepository(ExerciseLogDbContext context)
        {
            this._context = context;
        }

        public Status Add(CalisthenicExercise exercise)
        {
            if (exercise == null) 
                return _status.ResultWas(StatusResult.Error).WithMessage("Exercise can not be null.");

            Trainee Trainee = _context.Trainees.Find(exercise.TraineeId);
            if(Trainee == null)
                return _status.ResultWas(StatusResult.Error).WithMessage("There's no Trainee with that ID.");

            exercise.Trainee = Trainee;
            _context.CalisthenicExercises.Add(exercise);

            if (_context.SaveChanges() < 1)
                return _status.ResultWas(StatusResult.Error).WithMessage("It was not inserted properly.");

            return _status.ResultWas(StatusResult.Correct);
        }

        public async Task<Status> DeleteAsync(int id)
        {
            if(id < 1)
                return _status.ResultWas(StatusResult.Error).WithMessage("Id can not be less than 1.");

            CalisthenicExercise Exercise = await _context.CalisthenicExercises.FindAsync(id);
            _context.CalisthenicExercises.Remove(Exercise);

            if (_context.SaveChanges() < 1)
                return _status.ResultWas(StatusResult.Error).WithMessage("It was not deleted properly.");

            return _status.ResultWas(StatusResult.Correct);
        }

        public async Task<List<CalisthenicExercise>> GetAll()
        {
            List<CalisthenicExercise> exerciseList = await _context.CalisthenicExercises.Include(m => m.Exercise).Include(m => m.Trainee)?.ToListAsync();

            return exerciseList;
        }

        public async Task<CalisthenicExercise> GetById(int id)
        {

            CalisthenicExercise exerciseItem = await _context.CalisthenicExercises
                .Include(m => m.Exercise)
                .Include(m => m.Trainee)
                .Where(m => m.Id == id).FirstOrDefaultAsync();

            if (exerciseItem == null) return null;

            return exerciseItem;
        }

        public Status Update(CalisthenicExercise entity)
        {
            if (entity == null)
                return _status.ResultWas(StatusResult.Error).WithMessage("Exercise can not be null.");

            _context.CalisthenicExercises.Update(entity);

            if (_context.SaveChanges() < 1)
                return _status.ResultWas(StatusResult.Error).WithMessage("It was not updated properly.");

            return _status.ResultWas(StatusResult.Correct);
        }
    }
}
