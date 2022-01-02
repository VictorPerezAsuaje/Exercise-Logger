using ExerciseLog.Domain.EntidadesAuxiliares;
using ExerciseLog.Domain.Entities;
using System;

namespace ExerciseLog.Domain.DTO
{
    public class DistanceExerciseGetDTO : ExerciseGetDTO
    {
        public int Time { get; set; }
        public int Meters { get; set; }
    }
}
