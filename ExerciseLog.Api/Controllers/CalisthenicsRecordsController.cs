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
    public class CalisthenicsRecordsController : ControllerBase
    {
        private readonly IExerciseRepository<CalisthenicExercise> _calisthenicRepository;
        private readonly IReadOnlyRepository<Exercise> _exerciseRepository;
        private Status statusOperacion = new Status();

        public CalisthenicsRecordsController(IExerciseRepository<CalisthenicExercise> calisthenicRepository
            , IReadOnlyRepository<Exercise> exerciseRepository)
        {
            _calisthenicRepository = calisthenicRepository;
            _exerciseRepository = exerciseRepository;
        }
        // POST api/<ExerciseController>
        [HttpPost]
        public Status Post([FromBody] CalisthenicExercisePostDTO newExerciseDTO)
        {
            if (ModelState.IsValid)
            {
                Exercise exercise = _exerciseRepository.GetByName(newExerciseDTO.ExerciseName);

                if (exercise == null)
                    return statusOperacion.ResultWas(StatusResult.Error).WithMessage("There's no exercise with that name.");

                CalisthenicExercise calisthenicExercise = new CalisthenicExercise()
                {
                    ExerciseId = exercise.Id,
                    Exercise = exercise,
                    ExtraWeight = newExerciseDTO.ExtraWeight,
                    AddedWeight = newExerciseDTO.AddedWeight,
                    TotalAmount = newExerciseDTO.TotalAmount,
                    TraineeId = newExerciseDTO.TraineeId
                };

                return _calisthenicRepository.Add(calisthenicExercise);
            }

            return statusOperacion
                .ResultWas(StatusResult.Error)
                .WithMessage("Exercise was not created, please check all required elements.");
        }

        // GET: api/<ExerciseController>
        [HttpGet]
        public async Task<IEnumerable<ExerciseGetDTO>> Get()
        {
            List<CalisthenicExercise> exerciseList = await _calisthenicRepository.GetAll();
            List<ExerciseGetDTO> exerciseGetDTO = new List<ExerciseGetDTO>();

            exerciseList.ForEach(async exerciseItem =>
            {

                exerciseGetDTO.Add(new CalisthenicExerciseGetDTO()
                {
                    Id = exerciseItem.Id,
                    ExerciseName = exerciseItem.Exercise != null ? exerciseItem.Exercise.Name : (await _exerciseRepository.GetById(exerciseItem.ExerciseId)).Name,
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

            CalisthenicExercise exerciseItem = await _calisthenicRepository.GetById(id);

            if(exerciseItem == null) return new CalisthenicExerciseGetDTO() { 
                Status = statusOperacion.ResultWas(StatusResult.Error).WithMessage("There is not an exercise with that Id.") };

            return new CalisthenicExerciseGetDTO()
            {
                Id = exerciseItem.Id,
                ExerciseName = exerciseItem.Exercise.Name,
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
        public async Task<Status> Put(int id, [FromBody] CalisthenicExercisePostDTO newExerciseDTO)
        {
            if (id < 1) return statusOperacion.ResultWas(StatusResult.Error).WithMessage("Exercise was not updated, please use a valid ID.");

            if (newExerciseDTO == null) return statusOperacion.ResultWas(StatusResult.Error).WithMessage("Exercise was not created, please check all required elements.");

            CalisthenicExercise calisthenicExercise = await _calisthenicRepository.GetById(id);

            if (calisthenicExercise == null) 
                return statusOperacion.ResultWas(StatusResult.Error).WithMessage("Exercise was not updated, there is not Exercise with that Id.");

            Exercise exercise = _exerciseRepository.GetByName(newExerciseDTO.ExerciseName);


            if (exercise == null)
                return statusOperacion.ResultWas(StatusResult.Error).WithMessage("There's no exercise with that name.");

            calisthenicExercise.Exercise = exercise;
            calisthenicExercise.TotalAmount = newExerciseDTO.TotalAmount;
            calisthenicExercise.AddedWeight = newExerciseDTO.AddedWeight;
            calisthenicExercise.ExtraWeight = newExerciseDTO.ExtraWeight;
            calisthenicExercise.TraineeId = newExerciseDTO.TraineeId;

            return _calisthenicRepository.Update(calisthenicExercise);
        }

        // DELETE api/<ExerciseController>/5
        [HttpDelete("{id}")]
        public async Task<Status> Delete(int id)
        {
            if (id < 1)
                return statusOperacion.ResultWas(StatusResult.Error).WithMessage("Id can not be lower than 1");

            return await _calisthenicRepository.DeleteAsync(id);             
        }
    }
}
