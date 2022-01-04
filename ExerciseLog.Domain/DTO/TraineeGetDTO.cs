using ExerciseLog.Domain.EntidadesAuxiliares;
using ExerciseLog.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ExerciseLog.Domain.DTO
{
    public class TraineeGetDTO
    {
        public string TraineeName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Status Status { get; set; }
        public List<ExerciseGetDTO> CompletedExercises { get; set; }
    }
}
