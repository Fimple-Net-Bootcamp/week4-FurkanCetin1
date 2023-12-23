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
    public class FoodController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FoodController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodDto>>> GetFoods()
        {
            var foods = await _context.Foods.ToListAsync();
            var foodDtos = _mapper.Map<IEnumerable<FoodDto>>(foods);
            return Ok(foodDtos);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> AddFoodToPet(int id,[FromBody] Food food)
        {
            return Ok();
        }
    }
}