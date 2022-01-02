using ExerciseLog.Domain.EntidadesAuxiliares;
using ExerciseLog.Domain.Entities;

namespace ExerciseLog.Domain.DTO
{
    public class DistanceExercisePostDTO : ExercisePostDTO
    {
        public int Time { get; set; }
        public int Meters { get; set; }
    }
}
