using appointment_scheduler_api.Models;
using AutoMapper;

namespace appointment_scheduler_api.DTOs.users
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}