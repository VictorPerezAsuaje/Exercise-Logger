using ExerciseLog.Domain.EntidadesAuxiliares;
using ExerciseLog.Domain.Entities;

namespace ExerciseLog.Domain.DTO
{
    public class ExercisePostDTO
    {
        public string Name { get; set; }
        public bool ExtraWeight { get; set; }
        public int AddedWeight { get; set; }
        public MeasuredBy MeasuredBy { get; set; }
        public int TotalAmount { get; set; }
        public int TraineeId { get; set; }
    }
}
