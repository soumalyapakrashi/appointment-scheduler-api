using appointment_scheduler_api.DTOs.meetings;
using appointment_scheduler_api.Models;

namespace appointment_scheduler_api.Services.meetings
{
    public interface IMeetingService
    {
        Task<ServiceResponse<CreateMeetingResponseDto>> AddMeeting(CreateMeetingRequestDto new_meeting);
        Task<ServiceResponse<MeetingYearResponseDto>> GetMeetingsByYear(string year, string email);
    }
}