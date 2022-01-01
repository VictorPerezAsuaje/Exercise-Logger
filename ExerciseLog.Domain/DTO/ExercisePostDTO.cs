using ExerciseLog.Domain.EntidadesAuxiliares;

namespace ExerciseLog.Domain.DTO
{
    public class ExercisePostDTO
    {
        public string Name { get; set; }
        public bool ExtraWeight { get; set; }
        public int AddedWeight { get; set; }
        public int TotalReps { get; set; }
        public int TraineeId { get; set; }
    }
}
