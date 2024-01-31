using appointment_scheduler_api.Models;
using AutoMapper;

namespace appointment_scheduler_api.DTOs.meetings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CreateMeetingRequestDto, Meeting>();
            CreateMap<Meeting, CreateMeetingResponseDto>();
        }
    }
}