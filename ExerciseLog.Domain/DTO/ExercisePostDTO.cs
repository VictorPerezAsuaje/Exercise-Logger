using ExerciseLog.Domain.EntidadesAuxiliares;
using ExerciseLog.Domain.Entities;
using System;

namespace ExerciseLog.Domain.DTO
{
    public abstract class ExercisePostDTO
    {
        public string ExerciseName { get; set; }
        public bool ExtraWeight { get; set; }
        public int AddedWeight { get; set; }
        public int TraineeId { get; set; }
    }
}
