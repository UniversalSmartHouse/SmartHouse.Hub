using AutoMapper;
using SmartHouseHub.API.DTOs;
using SmartHouseHub.API.Model;

namespace SmartHouseHub.API
{
    public static class MapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<UserDto, User>().ReverseMap();
            });
        }
    }
}
