using ExerciseLog.Domain.EntidadesAuxiliares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLog.Domain.Entities
{
    public class Exercise : BaseEntity
    {
        public string Name { get; set; }
        public DifficultyLevel Difficulty { get; set; }
        public virtual CalisthenicExercise CalisthenicExercise { get; set; }
        public virtual DistanceExercise DistanceExercise { get; set; }
    }
}
