using System;
using System.Collections.Generic;
using System.Formats.Asn1;
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
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User object is null");
            }

            var user = _mapper.Map<User>(userDto);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpGet("istatistikler/{userId}")]
        public async Task<ActionResult<UserPetStatisticsDto>> GetUserPetStatistics([FromQuery]int userId)
        {
            var userPets = await _context.Pets
                .Where(p => p.Id == userId)
                .ToListAsync();

            var petIds = userPets.Select(p => p.Id).ToList();

            var activitiesCount = await _context.Avtivities
                .CountAsync(a => petIds.Contains(a.Id));

            var healthStatusCount = await _context.HealthStatuses
                .CountAsync(h => petIds.Contains(h.Id));

            var foodCount = await _context.Foods
                .CountAsync(f => petIds.Contains(f.Id));

            var userPetStatistics = new UserPetStatisticsDto
            {
                UserId = userId,
                PetCount = userPets.Count,
                TotalActivitiesCount = activitiesCount,
                TotalHealthStatusesCount = healthStatusCount,
                TotalFoodItemsCount = foodCount
            };

            return Ok(userPetStatistics);
        }
    }
}