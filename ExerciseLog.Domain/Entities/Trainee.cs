using ExerciseLog.Domain.EntidadesAuxiliares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLog.Domain.Entities
{
    public enum Gender
    {
        Male = 0,
        Female = 1
    }
    public class Trainee : BaseEntity
    {
        public string TraineeName { get; set; }
        public int Age { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public List<CalisthenicExercise> CalistenicExercises { get; set; } = new List<CalisthenicExercise>();
        public List<DistanceExercise> DistanceExercises { get; set; } = new List<DistanceExercise>();

        public Trainee()
        {
            // EF Required
        }

        public Trainee(DateTime birthDate)
        {
            this.DateOfBirth = birthDate;
            this.Age = GetAge();
        }

        public int GetAge()
        {
            int today = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dateOfBirth = int.Parse(this.DateOfBirth.ToString("yyyyMMdd"));
            return (today - dateOfBirth) / 10000;
        }
    }
}
