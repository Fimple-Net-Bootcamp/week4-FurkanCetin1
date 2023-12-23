using AutoMapper;
using Week03.Dto;
using Week03.Models;

namespace Week03.Mapping
{
    public class FoodProfile:Profile
    {
        public FoodProfile()
        {
            CreateMap<Food, FoodDto>().ReverseMap();
        }
    }
}
