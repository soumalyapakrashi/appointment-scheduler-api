namespace appointment_scheduler_api.DTOs.auth
{
    public class UserLoginRequestDto
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}