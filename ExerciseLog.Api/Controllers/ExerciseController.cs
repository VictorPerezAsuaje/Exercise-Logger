using ExerciseLog.Domain.DTO;
using ExerciseLog.Domain.EntidadesAuxiliares;
using ExerciseLog.Domain.Entities;
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
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseRepository _ExerciseRepository;
        private Status statusOperacion = new Status();

        public ExerciseController(IExerciseRepository ExerciseRepository)
        {
            _ExerciseRepository = ExerciseRepository;
        }
        // POST api/<ExerciseController>
        [HttpPost]
        public Status Post([FromBody] ExercisePostDTO newExerciseDTO)
        {
            if (ModelState.IsValid)
            {
                Exercise Exercise = new Exercise()
                {
                    Name = newExerciseDTO.Name,
                    ExtraWeight = newExerciseDTO.ExtraWeight,
                    AddedWeight = newExerciseDTO.AddedWeight,
                    TotalAmount = newExerciseDTO.TotalAmount,
                    TraineeId = newExerciseDTO.TraineeId
                };

                return _ExerciseRepository.Add(Exercise);
            }

            return statusOperacion
                .ResultWas(StatusResult.Error)
                .WithMessage("Exercise was not created, please check all required elements.");
        }

        // GET: api/<ExerciseController>
        [HttpGet]
        public async Task<IEnumerable<ExerciseGetDTO>> Get()
        {
            List<Exercise> exerciseList = await _ExerciseRepository.GetAll();
            List<ExerciseGetDTO> exerciseGetDTO = new List<ExerciseGetDTO>();

            exerciseList?.ForEach(exerciseItem =>
            {
                exerciseGetDTO.Add(new ExerciseGetDTO()
                {
                    Id = exerciseItem.Id,
                    Name = exerciseItem.Name,
                    AddedWeight = exerciseItem.AddedWeight,
                    ExtraWeight = exerciseItem.ExtraWeight,
                    ExerciseDate = exerciseItem.ExerciseDate,
                    TotalAmount = exerciseItem.TotalAmount,
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

            Exercise exerciseItem = await _ExerciseRepository.GetById(id);

            if(exerciseItem == null) return new ExerciseGetDTO() { 
                Status = statusOperacion.ResultWas(StatusResult.Error).WithMessage("There is not an exercise with that Id.") };

            return new ExerciseGetDTO()
            {
                Id = exerciseItem.Id,
                Name = exerciseItem.Name,
                AddedWeight = exerciseItem.AddedWeight,
                ExtraWeight = exerciseItem.ExtraWeight,
                ExerciseDate = exerciseItem.ExerciseDate,
                TotalAmount = exerciseItem.TotalAmount,
                TraineeName = exerciseItem.Trainee.TraineeName,
                Status = statusOperacion.ResultWas(StatusResult.Correct)
            };
        }

        // PUT api/<ExerciseController>/5
        [HttpPut("{id}")]
        public async Task<Status> Put(int id, [FromBody] ExercisePostDTO newExerciseDTO)
        {
            if (id < 1) return statusOperacion.ResultWas(StatusResult.Error).WithMessage("Exercise was not updated, please use a valid ID.");

            if (newExerciseDTO == null) return statusOperacion.ResultWas(StatusResult.Error).WithMessage("Exercise was not created, please check all required elements.");

            Exercise Exercise = await _ExerciseRepository.GetById(id);

            if (Exercise == null) 
                return statusOperacion.ResultWas(StatusResult.Error).WithMessage("Exercise was not updated, there is not Exercise with that Id.");

            Exercise.Name = newExerciseDTO.Name;
            Exercise.TotalAmount = newExerciseDTO.TotalAmount;
            Exercise.AddedWeight = newExerciseDTO.AddedWeight;
            Exercise.ExtraWeight = newExerciseDTO.ExtraWeight;
            Exercise.TraineeId = newExerciseDTO.TraineeId;

            return _ExerciseRepository.Update(Exercise);
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
