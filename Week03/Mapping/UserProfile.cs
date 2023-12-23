using AutoMapper;
using Week03.Dto;
using Week03.Models;

namespace Week03.Mapping
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
