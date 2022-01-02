using ExerciseLog.Domain.EntidadesAuxiliares;
using ExerciseLog.Domain.Entities;
using System;

namespace ExerciseLog.Domain.DTO
{
    public abstract class ExerciseGetDTO
    {
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public bool ExtraWeight { get; set; }
        public int AddedWeight { get; set; }
        public DateTime ExerciseDate { get; set; }
        public string TraineeName { get; set; }
        public Status Status { get; set; }
    }
}
