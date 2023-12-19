using appointment_scheduler_api.Models;
using AutoMapper;

namespace appointment_scheduler_api.DTOs.auth
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<UserSignUpRequestDto, User>();
            CreateMap<UserSignUpRequestDto, UserSignUpResponseDto>();

            CreateMap<UserLoginRequestDto, User>();
            CreateMap<User, UserSignUpResponseDto>();
        }
    }
}