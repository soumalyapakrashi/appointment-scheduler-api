using System.Globalization;
using appointment_scheduler_api.Data;
using appointment_scheduler_api.DTOs.meetings;
using appointment_scheduler_api.DTOs.users;
using appointment_scheduler_api.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace appointment_scheduler_api.Services.meetings
{
    public class MeetingService : IMeetingService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MeetingService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;     
        }

        public async Task<ServiceResponse<CreateMeetingResponseDto>> AddMeeting(CreateMeetingRequestDto new_meeting)
        {
            var serviceResponse = new ServiceResponse<CreateMeetingResponseDto>();

            try
            {
                // Resolve the attendees of the meeting if present
                var attendeeList = new List<User>();
                if(new_meeting.Attendees is not null)
                {
                    foreach(UserDto attendee in new_meeting.Attendees)
                    {
                        var attendeeUser = await _context.Users.Where(userFromDb => userFromDb.Email == attendee.Email).ToListAsync();
                        if(attendeeUser is null || attendeeUser.Count == 0)
                        {
                            throw new Exception($"Attendee with email {attendee.Email} not found");
                        }
                        else
                        {
                            attendeeList.Add(attendeeUser[0]);
                        }
                    }
                }

                // Create a new meeting object from input data
                var meetingObj = new Meeting {
                    Title = new_meeting.Title,
                    Description = new_meeting.Description,
                    Attendees = attendeeList,
                    StartDate = DateTime.ParseExact(new_meeting.StartDate, "MM/dd/yyyy hh:mm:ss tt", new CultureInfo("en-US")),
                    EndDate = DateTime.ParseExact(new_meeting.EndDate, "MM/dd/yyyy hh:mm:ss tt", new CultureInfo("en-US"))
                };

                // Update database and push the new meeting
                _context.Meetings.Add(meetingObj);
                await _context.SaveChangesAsync();

                // Prepare the response on successful insertion into database
                var meetingResponseObj = new CreateMeetingResponseDto {
                    Id = meetingObj.Id,
                    Title = meetingObj.Title,
                    Description = meetingObj.Description,
                    Attendees = _mapper.Map<List<UserDto>>(meetingObj.Attendees),
                    StartDate = meetingObj.StartDate.ToString(),
                    EndDate = meetingObj.EndDate.ToString()
                };
                serviceResponse.Data = _mapper.Map<CreateMeetingResponseDto>(meetingResponseObj);
                serviceResponse.Success = true;
                serviceResponse.Message = "Meeting created successfully";
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<MeetingYearResponseDto>> GetMeetingsByYear(string year, string email)
        {
            var serviceResponse = new ServiceResponse<MeetingYearResponseDto>();

            try
            {
                var currentLoggedInUser = await _context.Users.Where(userFromDb => userFromDb.Email == email).ToListAsync();
                var meetingsInSpecifiedYear = await _context.Meetings.Where(meetingFromDb => meetingFromDb.Attendees.Contains(currentLoggedInUser[0])).ToListAsync();

                
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }
    }
}