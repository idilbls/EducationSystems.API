using EducationSystems.Shared.DTOs;
using EducationSystems.Shared.DTOs.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystems.BusinessLogic.Abstract
{
    public interface IUserService
    {
        Task<bool> Register(RegisterDto request);
        Task<LoginResponseDto> Login(LoginDto request);
        Task<UserDto> GetUserById(int id);
        Task<bool> UpdateLocalAddress(LocalAddressRequest request);
    }
}
