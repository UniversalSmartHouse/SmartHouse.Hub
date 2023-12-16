using SmartHouseHub.API.DTOs;

namespace SmartHouseHub.API.Interfaces
{
    public interface IUserService
    {
        UserDto Insert(UserDto obj);
        UserDto Update(UserDto obj);
    }
}
