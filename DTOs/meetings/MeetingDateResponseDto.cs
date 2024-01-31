using appointment_scheduler_api.DTOs.users;

namespace appointment_scheduler_api.DTOs.meetings
{
    public class MeetingDateResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public UserDto Host { get; set; } = new UserDto();
        public DateTime Date { get; set; }
    }
}