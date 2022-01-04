using ExerciseLog.Domain.EntidadesAuxiliares;
using ExerciseLog.Domain.Entities;

namespace ExerciseLog.Domain.DTO
{
    public class DistanceExercisePostDTO : ExercisePostDTO
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Meters { get; set; }
    }
}
