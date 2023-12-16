using Microsoft.AspNetCore.Mvc;
using SmartHouseHub.API.DTOs;
using SmartHouseHub.API.Interfaces;

namespace SmartHouseHub.API.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        public readonly IUserService _userService;
        public UserController(IUserService logService)
        {
            _userService = logService;
        }

        [HttpPost("")]
        public UserDto Insert([FromBody] UserDto obj)
        {
            try
            {
                return _userService.Insert(obj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("")]
        public UserDto Update([FromBody] UserDto obj)
        {
            try
            {
                return _userService.Update(obj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
