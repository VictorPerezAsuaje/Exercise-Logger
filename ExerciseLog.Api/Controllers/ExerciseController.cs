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
    public class ExerciseController : ControllerBase
    {
        private readonly IReadOnlyExerciseRepository<Exercise> _exerciseRepository;
        private Status statusOperacion = new Status();

        public ExerciseController(IReadOnlyExerciseRepository<Exercise> ExerciseRepository
            , ExerciseLogDbContext context)
        {
            _exerciseRepository = ExerciseRepository;
        }

        // GET: api/<ExerciseController>
        [HttpGet]
        public async Task<IEnumerable<Exercise>> Get()
        {
            List<Exercise> exerciseList = await _exerciseRepository.GetAll();

            return exerciseList;
        }

        // GET api/<ExerciseController>/5
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<Exercise> GetById(int id) 
        {
            if (id < 1) 
                return null;

            return await _exerciseRepository.GetById(id);
        }

        // GET api/<ExerciseController>/name
        [HttpGet("GetByName/{name}")]
        public async Task<IEnumerable<Exercise>> GetByName(string name)
        {
            if (name.Trim() == "")
                return null;

            return await _exerciseRepository.GetByName(name);
        }
    }
}
