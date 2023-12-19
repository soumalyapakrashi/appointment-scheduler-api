using appointment_scheduler_api.Data;
using appointment_scheduler_api.DTOs.auth;
using appointment_scheduler_api.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace appointment_scheduler_api.Services.auth
{
    public class UserAuthService : IUserAuthService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserAuthService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            
        }

        public async Task<ServiceResponse<UserSignUpResponseDto>> LoginUser(UserLoginRequestDto user)
        {
            var serviceResponse = new ServiceResponse<UserSignUpResponseDto>();

            try
            {
                var dbUser = await _context.Users.Where(userFromDb => userFromDb.Email == user.Email).ToListAsync();
                
                // When user not found in User table
                if(dbUser is null || dbUser.Count == 0)
                {
                    throw new Exception("User not registered or invalid credentials");
                }

                // When user found, but password do not match
                if(dbUser[0].Password != user.Password)
                {
                    throw new Exception("User not found or invalid credentials");
                }

                serviceResponse.Data = _mapper.Map<UserSignUpResponseDto>(dbUser[0]);
                serviceResponse.Success = true;
                serviceResponse.Message = "User login successful";
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<UserSignUpResponseDto>> SignUpUser(UserSignUpRequestDto newUser)
        {
            var serviceResponse = new ServiceResponse<UserSignUpResponseDto>();

            try
            {
                // Load data into the database
                _context.Add(_mapper.Map<User>(newUser));
                await _context.SaveChangesAsync();

                // On success, return the user details
                serviceResponse.Data = _mapper.Map<UserSignUpResponseDto>(newUser);
                serviceResponse.Success = true;
                serviceResponse.Message = "User sign-up successful";
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