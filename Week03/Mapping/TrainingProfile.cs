using AutoMapper;
using Week03.Dto;
using Week03.Models;

namespace Week03.Mapping
{
    public class TrainingProfile:Profile
    {
        public TrainingProfile()
        {
            CreateMap<Training, TrainingDto>().ReverseMap();
        }
    }
}
