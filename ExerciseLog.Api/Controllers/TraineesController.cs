using ExerciseLog.Domain.DTO;
using ExerciseLog.Domain.EntidadesAuxiliares;
using ExerciseLog.Domain.Entities;
using ExerciseLog.Domain.Interfaces;
using ExerciseLog.Infrastructure.Data;
using ExerciseLog.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseLog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineesController : ControllerBase
    {
        private readonly IReadOnlyRepository<Trainee> _traineeRepository;

        public TraineesController(IReadOnlyRepository<Trainee> traineeRepository)
        {
            _traineeRepository = traineeRepository;
        }

        // GET api/<TraineeController>/5
        [HttpGet]
        [Route("{id}")]
        public async Task<TraineeGetDTO> GetById(int id) 
        {
            if (id < 1) 
                return null;

            Trainee trainee = await _traineeRepository.GetById(id);
            List<ExerciseGetDTO> exerciseGetDTOs = new List<ExerciseGetDTO>();
            trainee.CalistenicExercises.ForEach(ce => exerciseGetDTOs.Add(new ExerciseGetDTO()
            {
                Id = ce.Id,
                AddedWeight = ce.AddedWeight,
                ExerciseDate = ce.ExerciseDate,
                ExerciseName = ce.Exercise.Name,
                ExtraWeight = ce.ExtraWeight,
                TraineeName = ce.Trainee.TraineeName
            }));

            TraineeGetDTO traineeGetDTO = new TraineeGetDTO()
            {
                TraineeName = trainee.TraineeName,
                Age = trainee.Age,
                Gender = trainee.Gender,
                DateOfBirth = trainee.DateOfBirth,
                CompletedExercises = exerciseGetDTOs.ToList()
            };

            return traineeGetDTO;
        }
    }
}
