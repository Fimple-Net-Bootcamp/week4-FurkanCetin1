using AutoMapper;
using Week03.Dto;
using Week03.Models;

namespace Week03.Mapping
{
    public class ActivityProfile:Profile
    {
        public ActivityProfile()
        {
            CreateMap<Activity,ActivityDto>().ReverseMap();
        }
    }
}
