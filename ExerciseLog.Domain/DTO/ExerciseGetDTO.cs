using ExerciseLog.Domain.EntidadesAuxiliares;
using System;

namespace ExerciseLog.Domain.DTO
{
    public class ExerciseGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ExtraWeight { get; set; }
        public int AddedWeight { get; set; }
        public int TotalReps { get; set; }
        public DateTime ExerciseDate { get; set; }
        public string TraineeName { get; set; }
    }
}
