using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week03.Data;
using Week03.Dto;
using Week03.Models;

namespace Week03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TrainingController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostTraining([FromBody] TrainingDto trainingDto)
        {
            var training = _mapper.Map<Training>(trainingDto);

            _context.Trainings.Add(training);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<TrainingDto>(training));
        }

        [HttpGet("{petId}")]
        public async Task<ActionResult<IEnumerable<TrainingDto>>> GetTrainings(int petId)
        {
            var trainings = await _context.Trainings
                .Where(t => t.PetId == petId)
                .ToListAsync();

            if (!trainings.Any())
            {
                return NotFound();
            }

            var trainingDtos = _mapper.Map<IEnumerable<TrainingDto>>(trainings);
            return Ok(trainingDtos);
        }
    }
}
