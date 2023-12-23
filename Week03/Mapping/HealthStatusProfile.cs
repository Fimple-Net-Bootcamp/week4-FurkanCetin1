using AutoMapper;
using Week03.Dto;
using Week03.Models;

namespace Week03.Mapping
{
    public class HealthStatusProfile:Profile
    {
        public HealthStatusProfile()
        {
            CreateMap<HealthStatus, HealthStatusDto>().ReverseMap();
        }
    }
}
