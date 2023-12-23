using AutoMapper;
using Week03.Dto;
using Week03.Models;

namespace Week03.Mapping
{
    public class SocialInteractionProfile : Profile
    {
        public SocialInteractionProfile()
        {
            CreateMap<SocialInteraction, SocialInteractionDto>().ReverseMap();
        }
    }
}
