using appointment_scheduler_api.DTOs.users;

namespace appointment_scheduler_api.DTOs.meetings
{
    public class CreateMeetingRequestDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<UserDto> Attendees { get; set; } = new();
        public string StartDate { get; set; } = DateTime.Now.ToString();
        public string EndDate { get; set; } = string.Empty;
    }
}