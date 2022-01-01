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
        Male,
        Female
    }
    public class Trainee : BaseEntity
    {
        public string TraineeName { get; set; }
        public int Age { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public List<Exercise> ExerciseRecord { get; set; } = new List<Exercise>();

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
