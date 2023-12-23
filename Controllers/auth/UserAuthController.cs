using appointment_scheduler_api.DTOs.auth;
using appointment_scheduler_api.Models;
using appointment_scheduler_api.Services.auth;
using Microsoft.AspNetCore.Mvc;

namespace appointment_scheduler_api.Controllers.auth
{
    [ApiController]
    [Route("auth/")]
    public class UserAuthController : ControllerBase
    {
        private readonly IUserAuthService _userAuthService;

        public UserAuthController(IUserAuthService userAuthService)
        {
            _userAuthService = userAuthService;
            
        }

        [HttpPost("signup")]
        public async Task<ActionResult<ServiceResponse<UserSignUpResponseDto>>> AddUserSignUp(UserSignUpRequestDto newUser)
        {
            var response = await _userAuthService.SignUpUser(newUser);
            if(response.Success == true)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<UserSignUpResponseDto>>> AddUserLogin(UserLoginRequestDto user)
        {
            var response = await _userAuthService.LoginUser(user);
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
