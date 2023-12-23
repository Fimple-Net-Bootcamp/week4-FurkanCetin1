using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week03.Data;
using Week03.Dto;
using Week03.Models;

namespace Week03.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PetController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("CreatePet")]
        public async Task<IActionResult> CreatePet([FromBody] PetDto petDto)
        {
            if (petDto == null)
            {
                return BadRequest();
            }

            var pet = _mapper.Map<Pet>(petDto);
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<PetDto>(pet));
        }

        [HttpGet("GetPetList")]
        public async Task<ActionResult<IEnumerable<PetDto>>> GetPetList()
        {
            var petList = await _context.Pets.ToListAsync();
            var petListDto = _mapper.Map<IEnumerable<PetDto>>(petList);

            return Ok(petListDto);
        }

        [HttpGet("GetPet/{id}")]
        public async Task<IActionResult> GetPet(int id)
        {
            var pet = await _context.Pets.FirstOrDefaultAsync(p => p.Id == id);
            if (pet == null)
            {
                return NotFound();
            }

            var petDto = _mapper.Map<PetDto>(pet);
            return Ok(petDto);
        }

        [HttpPut("UpdatePet/{id}")]
        public async Task<IActionResult> UpdatePet(int id, [FromBody] PetDto petDto)
        {
            if (id != petDto.Id || petDto == null)
            {
                return BadRequest();
            }

            var existPet = await _context.Pets.FindAsync(id);
            if (existPet == null)
            {
                return NotFound();
            }

            _mapper.Map(petDto, existPet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("istatistikler/{petId}")]
        public async Task<ActionResult<PetStatisticsDto>> GetPetStatistics(int petId)
        {
            var activities = await _context.Avtivities
                .Where(a => a.Id == petId)
                .ToListAsync();

            var healthStatus = await _context.HealthStatuses
                .FirstOrDefaultAsync(h => h.Id == petId);

            var foods = await _context.Foods
                .Where(f => f.Id == petId)
                .ToListAsync();

            var petStatistics = new PetStatisticsDto
            {
                PetId = petId,
                ActivityCount = activities.Count,
                LastHealthCheckup = healthStatus?.CheckupDate,
                FoodCount = foods.Count
            };

            return Ok(petStatistics);
        }
    }
}