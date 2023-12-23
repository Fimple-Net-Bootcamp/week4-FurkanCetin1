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
    public class ActivityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ActivityController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ActivityDto>> PostActivity([FromBody]ActivityDto activityDto)
        {
            var activity = _mapper.Map<Activity>(activityDto);

            _context.Avtivities.Add(activity);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<ActivityDto>(activity));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivities(int id)
        {
            var activities = await _context.Avtivities
            .Where(a => a.Id == id)
            .ToListAsync();

            if (!activities.Any())
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<ActivityDto>>(activities));
        }
    }
}