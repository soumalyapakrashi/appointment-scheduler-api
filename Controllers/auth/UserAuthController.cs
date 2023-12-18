using appointment_scheduler_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace appointment_scheduler_api.Controllers.auth
{
    [ApiController]
    [Route("auth/")]
    public class UserAuthController : ControllerBase
    {
        [HttpPost("signup")]
        public ActionResult<User> AddUserSignUp(User newUser)
        {
            return Ok(newUser);
        }
    }
}
