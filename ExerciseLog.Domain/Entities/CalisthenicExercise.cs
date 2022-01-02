using ExerciseLog.Domain.EntidadesAuxiliares;
using ExerciseLog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLog.Domain.Entities
{

    public class CalisthenicExercise : BaseEntity, IExerciseItem
    {
        public Exercise Exercise { get; set; }
        public bool ExtraWeight { get; set; }
        public int AddedWeight { get; set; }
        public DateTime ExerciseDate { get; set; }
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
        public MeasuredBy MeasuredBy { get; set; }
        public int TotalAmount { get; set; }

        public CalisthenicExercise()
        {
            this.ExerciseDate = DateTime.Now;
        }
    }
}
