using ExerciseLog.Domain.EntidadesAuxiliares;
using ExerciseLog.Domain.Entities;
using System;

namespace ExerciseLog.Domain.DTO
{
    public class DistanceExerciseGetDTO : ExerciseGetDTO
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Meters { get; set; }
    }
}
