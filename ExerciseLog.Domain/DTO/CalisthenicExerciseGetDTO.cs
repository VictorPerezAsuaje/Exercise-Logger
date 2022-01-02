using ExerciseLog.Domain.EntidadesAuxiliares;
using ExerciseLog.Domain.Entities;
using System;

namespace ExerciseLog.Domain.DTO
{
    public class CalisthenicExerciseGetDTO : ExerciseGetDTO
    {
        public MeasuredBy MeasuredBy { get; set; }
        public int TotalAmount { get; set; }
    }
}
