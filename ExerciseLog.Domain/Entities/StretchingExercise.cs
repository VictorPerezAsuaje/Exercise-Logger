using ExerciseLog.Domain.EntidadesAuxiliares;
using ExerciseLog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLog.Domain.Entities
{
    public class StretchingExercise : BaseEntity, IExerciseItem
    {
        public Exercise Exercise { get; set; }
        public DateTime ExerciseDate { get; set; }
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
        public int Time { get; set; }

        public StretchingExercise()
        {
            this.ExerciseDate = DateTime.Now;
        }
    }
}
