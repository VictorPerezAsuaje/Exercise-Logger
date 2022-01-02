using ExerciseLog.Domain.EntidadesAuxiliares;
using ExerciseLog.Domain.Entities;

namespace ExerciseLog.Domain.DTO
{
    public class CalisthenicExercisePostDTO : ExercisePostDTO
    {
        public MeasuredBy MeasuredBy { get; set; }
        public int TotalAmount { get; set; }
    }
}
