using appointment_scheduler_api.DTOs.users;
using appointment_scheduler_api.Models;
using appointment_scheduler_api.Services.users;
using Microsoft.AspNetCore.Mvc;

namespace appointment_scheduler_api.Controllers.users
{
    [ApiController]
    [Route("users/")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getallusers")]
        public async Task<ActionResult<ServiceResponse<List<UserDto>>>> GetAllUsers() {
            var response = await _userService.GetAllUsers();

            if(response.Success == true)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet("getuserbyemail")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> GetUserByEmail(string email) {
            var response = await _userService.GetUserByEmail(email);

            if(response.Success == true)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}