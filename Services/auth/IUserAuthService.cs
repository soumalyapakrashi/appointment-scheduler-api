using appointment_scheduler_api.DTOs.auth;
using appointment_scheduler_api.Models;

namespace appointment_scheduler_api.Services.auth
{
    public interface IUserAuthService
    {
        Task<ServiceResponse<UserSignUpResponseDto>> SignUpUser(UserSignUpRequestDto newUser);
        Task<ServiceResponse<UserSignUpResponseDto>> LoginUser(UserLoginRequestDto user);
    }
}