using appointment_scheduler_api.DTOs.users;

namespace appointment_scheduler_api.DTOs.meetings
{
    public class CreateMeetingResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<UserDto> Attendees { get; set; } = new();
        public string StartDate { get; set; } = string.Empty;
        public string? EndDate { get; set; }
    }
}