using ExerciseLog.Domain.Entities;
using System;

namespace ExerciseLog.Domain.Interfaces
{
    public interface IExerciseItem 
    {
        Exercise Exercise { get; set; }
        DateTime ExerciseDate { get; set; }
        int TraineeId { get; set; }
        Trainee Trainee { get; set; }
    }
}
