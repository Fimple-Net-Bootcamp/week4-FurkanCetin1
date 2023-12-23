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
    public class HealthStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HealthStatusController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HealthStatusDto>> GetHealthStatus([FromQuery]int id)
        {
            var healthStatus = await _context.HealthStatuses
                .FirstOrDefaultAsync(h => h.Id == id);

            if (healthStatus == null)
            {
                return NotFound();
            }

            var healthStatusDto = _mapper.Map<HealthStatusDto>(healthStatus);
            return Ok(healthStatusDto);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateHealthStatus(int id,[FromBody] HealthStatusDto healthStatusDto)
        {
            var healthStatus = await _context.HealthStatuses.FirstOrDefaultAsync(h => h.Id == id);

            if (healthStatus == null)
            {
                return NotFound();
            }

            _mapper.Map(healthStatusDto, healthStatus);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}