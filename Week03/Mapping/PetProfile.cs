using AutoMapper;
using Week03.Dto;
using Week03.Models;

namespace Week03.Mapping
{
    public class PetProfile:Profile
    {
        public PetProfile()
        {
            CreateMap<Pet, PetDto>().ReverseMap();
        }

    }
}
