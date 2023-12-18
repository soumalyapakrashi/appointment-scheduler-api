namespace appointment_scheduler_api.DTOs.auth
{
    public class UserSignUpResponseDto
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string? PhoneNumber { get; set; }
    }
}