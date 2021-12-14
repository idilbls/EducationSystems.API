using EducationSystems.BusinessLogic.Abstract;
using EducationSystems.Shared.DTOs;
using EducationSystems.Shared.DTOs.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSystems.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<bool> Register([FromBody]RegisterDto request)
        {
            return await _userService.Register(request);
        }


        [HttpPost("login")]
        public async Task<LoginResponseDto> Login([FromBody]LoginDto request)
        {
            return await _userService.Login(request);
        }

        [HttpPost("get_user_by_id")]
        public async Task<UserDto> GetUserById([FromBody] int id)
        {
            return await _userService.GetUserById(id);
        }

        [HttpPost("update_local_address")]
        public async Task<bool> UpdateLocalAddress([FromBody]LocalAddressRequest request)
        {
            return await _userService.UpdateLocalAddress(request);
        }
    }
}
