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
    public class SocialInteractionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SocialInteractionController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostSocialInteraction([FromBody] SocialInteractionDto socialInteractionDto)
        {
            var socialInteraction = _mapper.Map<SocialInteraction>(socialInteractionDto);

            _context.SocialInteractions.Add(socialInteraction);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<SocialInteractionDto>(socialInteraction));
        }

        [HttpGet("{petId}")]
        public async Task<ActionResult<IEnumerable<SocialInteractionDto>>> GetSocialInteractions(int petId)
        {
            var socialInteractions = await _context.SocialInteractions
                .Where(si => si.InitiatorPetId == petId || si.ParticipantPetId == petId)
                .ToListAsync();

            if (!socialInteractions.Any())
            {
                return NotFound();
            }

            var socialInteractionDtos = _mapper.Map<IEnumerable<SocialInteractionDto>>(socialInteractions);
            return Ok(socialInteractionDtos);
        }
    }
}
