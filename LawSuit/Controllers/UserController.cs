
using LawSuit.Application.Service.Interface;
using LawSuit.Domain.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LawSuit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppSerrvice _userAppService;
        public UserController(IUserAppSerrvice userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        public async Task CreateUser([FromQuery] UserDto userDto)
        {        
            await _userAppService.CreateUserAsync(userDto);
        }

        [HttpPut]
        public async Task UpdateUser([FromQuery] UserDto userDto)
        {
            await _userAppService.UpdateUserAsync(userDto);
        }

        [HttpGet("GetUserDetailsById/{id}")]
        public async Task GetUserDetailsById(int userId)
        {
            await _userAppService.GetUserDetailsByIdAsync(userId);
        }


    }
}
