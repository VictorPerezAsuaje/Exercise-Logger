using ExerciseLog.Domain.EntidadesAuxiliares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLog.Domain.Entities
{
    public enum MeasuredBy
    {
        Time,
        Repetitions
    }

    public class Exercise : BaseEntity
    {
        public string Name { get; set; }
        public bool ExtraWeight { get; set; }
        public int AddedWeight { get; set; }
        public MeasuredBy MeasuredBy { get; set; }
        public int TotalAmount { get; set; }
        public int Year { get; private set; }
        public int Month { get; private set; }
        public int Day { get; private set; }
        public DateTime ExerciseDate { get; private set; }
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }

        public Exercise()
        {
            this.ExerciseDate = DateTime.Now;
            this.Year = ExerciseDate.Year;
            this.Month = ExerciseDate.Month;
            this.Day = ExerciseDate.Day;
        }

    }
}
