using appointment_scheduler_api.DTOs.meetings;
using appointment_scheduler_api.Models;
using appointment_scheduler_api.Services.meetings;
using Microsoft.AspNetCore.Mvc;

namespace appointment_scheduler_api.Controllers.meetings
{
    [ApiController]
    [Route("meetings/")]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService _meetingService;

        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
            
        }

        // [HttpGet("bydate/")]
        // public async Task<ActionResult<ServiceResponse<List<MeetingDateResponseDto>>>> GetMeetingsByDate(string date, string email) {
        //     throw new NotImplementedException();
        // }

        // [HttpGet("bymonth/")]
        // public async Task<ActionResult<ServiceResponse<List<MeetingDateResponseDto>>>> GetMeetingsByMonth() {

        // }

        [HttpGet("year")]
        public async Task<ActionResult<ServiceResponse<List<MeetingYearResponseDto>>>> GetMeetingsByYear(string year, string email)
        {
            var response = await _meetingService.GetMeetingsByYear(year, email);
            
            if(response.Success == true)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("new")]
        public async Task<ActionResult<ServiceResponse<CreateMeetingResponseDto>>> AddMeeting(CreateMeetingRequestDto new_meeting)
        {
            var response = await _meetingService.AddMeeting(new_meeting);

            if(response.Success == true)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}