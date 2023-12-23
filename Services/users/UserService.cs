using appointment_scheduler_api.Data;
using appointment_scheduler_api.DTOs.users;
using appointment_scheduler_api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appointment_scheduler_api.Services.users
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;     
        }

        public async Task<ServiceResponse<List<UserDto>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<UserDto>>();

            try
            {
                var dbUsers = await _context.Users.ToListAsync();

                // dbUsers cannot be 0 as there has to be at minimum, a single user in the database
                if(dbUsers == null || dbUsers.Count ==0) {
                    throw new Exception("Internal Error: No users present");
                }

                serviceResponse.Data = dbUsers.Select(dbUser => _mapper.Map<UserDto>(dbUser)).ToList();
                serviceResponse.Success = true;
                serviceResponse.Message = "User fetch successful";
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