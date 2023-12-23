/*
    This class is a wrapper around the actual Data object which is being passed on to the client.
    This will help the client to better understand if the request succeeded or not.
    If not, this also provides an appropriate and concise message of what went wrong.
*/

namespace appointment_scheduler_api.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
    }
}
