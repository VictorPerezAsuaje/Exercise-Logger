using ExerciseLog.Domain.EntidadesAuxiliares;
using ExerciseLog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLog.Domain.Entities
{
    public class DistanceExercise : BaseEntity, IExerciseItem
    {
        public Exercise Exercise { get; set; }
        public bool ExtraWeight { get; set; }
        public int AddedWeight { get; set; }
        public DateTime ExerciseDate { get; set; }
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
        public int Time { get; set; }
        public int Meters { get; set; }

        public DistanceExercise()
        {
            this.ExerciseDate = DateTime.Now;
        }
    }
}
