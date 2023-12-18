using appointment_scheduler_api.Data;
using appointment_scheduler_api.DTOs.auth;
using appointment_scheduler_api.Models;
using AutoMapper;

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