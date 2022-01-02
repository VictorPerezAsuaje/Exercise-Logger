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
    public class DistanceExerciseController : ControllerBase
    {
        private readonly ExerciseLogDbContext _context;
        private readonly IExerciseRepository<DistanceExercise> _ExerciseRepository;
        private Status statusOperacion = new Status();

        public DistanceExerciseController(IExerciseRepository<DistanceExercise> ExerciseRepository
            , ExerciseLogDbContext context)
        {
            _ExerciseRepository = ExerciseRepository;
            _context = context;
        }
        // POST api/<ExerciseController>
        [HttpPost]
        public Status Post([FromBody] DistanceExercisePostDTO newExerciseDTO)
        {
            if (ModelState.IsValid)
            {
                Exercise exercise = _context.Exercises
                    .Where(e => e.Name.ToLower() == newExerciseDTO.ExerciseName.ToLower())
                    .FirstOrDefault();

                if (exercise == null)
                    return statusOperacion.ResultWas(StatusResult.Error).WithMessage("There's no exercise with that name.");

                DistanceExercise distanceExercise = new DistanceExercise()
                {
                    Exercise = exercise,
                    ExtraWeight = newExerciseDTO.ExtraWeight,
                    AddedWeight = newExerciseDTO.AddedWeight,
                    Meters = newExerciseDTO.Meters,
                    Time = newExerciseDTO.Time,
                    TraineeId = newExerciseDTO.TraineeId,
                };

                return _ExerciseRepository.Add(distanceExercise);
            }

            return statusOperacion
                .ResultWas(StatusResult.Error)
                .WithMessage("Exercise was not created, please check all required elements.");
        }

        // GET: api/<ExerciseController>
        [HttpGet]
        public async Task<IEnumerable<ExerciseGetDTO>> Get()
        {
            List<DistanceExercise> exerciseList = await _ExerciseRepository.GetAll();
            List<ExerciseGetDTO> exerciseGetDTO = new List<ExerciseGetDTO>();

            exerciseList?.ForEach(exerciseItem =>
            {
                exerciseGetDTO.Add(new DistanceExerciseGetDTO()
                {
                    Id = exerciseItem.Id,
                    ExerciseName = exerciseItem.Exercise.Name,
                    AddedWeight = exerciseItem.AddedWeight,
                    ExtraWeight = exerciseItem.ExtraWeight,
                    Meters = exerciseItem.Meters,
                    Time = exerciseItem.Time,
                    TraineeName = exerciseItem.Trainee.TraineeName,
                    Status = statusOperacion.ResultWas(StatusResult.Correct)
                });
            });

            return exerciseGetDTO;
        }

        // GET api/<ExerciseController>/5
        [HttpGet("{id}")]
        public async Task<ExerciseGetDTO> Get(int id) 
        {
            if (id < 1) 
                return null;

            DistanceExercise exerciseItem = await _ExerciseRepository.GetById(id);

            if(exerciseItem == null) return new DistanceExerciseGetDTO() { 
                Status = statusOperacion.ResultWas(StatusResult.Error).WithMessage("There is not an exercise with that Id.") };

            return new DistanceExerciseGetDTO()
            {
                Id = exerciseItem.Id,
                ExerciseName = exerciseItem.Exercise.Name,
                AddedWeight = exerciseItem.AddedWeight,
                ExtraWeight = exerciseItem.ExtraWeight,
                ExerciseDate = exerciseItem.ExerciseDate,
                Meters = exerciseItem.Meters,
                Time = exerciseItem.Time,
                TraineeName = exerciseItem.Trainee.TraineeName,
                Status = statusOperacion.ResultWas(StatusResult.Correct)
            };
        }

        // PUT api/<ExerciseController>/5
        [HttpPut("{id}")]
        public async Task<Status> Put(int id, [FromBody] DistanceExercisePostDTO newExerciseDTO)
        {
            if (id < 1) return statusOperacion.ResultWas(StatusResult.Error).WithMessage("Exercise was not updated, please use a valid ID.");

            if (newExerciseDTO == null) return statusOperacion.ResultWas(StatusResult.Error).WithMessage("Exercise was not created, please check all required elements.");

            DistanceExercise distanceExercise = await _ExerciseRepository.GetById(id);

            if (distanceExercise == null) 
                return statusOperacion.ResultWas(StatusResult.Error).WithMessage("Exercise was not updated, there is not Exercise with that Id.");

            Exercise exercise = _context.Exercises
                .Where(e => e.Name.ToLower() == newExerciseDTO.ExerciseName.ToLower())
                .FirstOrDefault();

            if (exercise == null)
                return statusOperacion.ResultWas(StatusResult.Error).WithMessage("There's no exercise with that name.");

            distanceExercise.Exercise = exercise;
            distanceExercise.Meters = newExerciseDTO.Meters;
            distanceExercise.Time = newExerciseDTO.Time;
            distanceExercise.AddedWeight = newExerciseDTO.AddedWeight;
            distanceExercise.ExtraWeight = newExerciseDTO.ExtraWeight;
            distanceExercise.TraineeId = newExerciseDTO.TraineeId;

            return _ExerciseRepository.Update(distanceExercise);
        }

        // DELETE api/<ExerciseController>/5
        [HttpDelete("{id}")]
        public async Task<Status> Delete(int id)
        {
            if (id < 1)
                return statusOperacion.ResultWas(StatusResult.Error).WithMessage("Id can not be lower than 1");

            return await _ExerciseRepository.DeleteAsync(id);             
        }
    }
}
