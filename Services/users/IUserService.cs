using appointment_scheduler_api.DTOs.users;
using appointment_scheduler_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace appointment_scheduler_api.Services.users
{
    public interface IUserService
    {
        Task<ServiceResponse<List<UserDto>>> GetAllUsers();
        Task<ServiceResponse<UserDto>> GetUserByEmail(string email);
    }
}