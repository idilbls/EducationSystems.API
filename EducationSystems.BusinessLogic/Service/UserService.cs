using EducationSystems.BusinessLogic.Abstract;
using EducationSystems.Models.Entities.IdentityAuth;
using EducationSystems.Shared.DTOs;
using EducationSystems.Shared.DTOs.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystems.BusinessLogic.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
                if(user != null)
                {
                    var userDto = new UserDto
                    {
                        Id = user.Id,
                        Username = user.UserName,
                        Name = user.Name,
                        Surname = user.Surname,
                        Number = user.Number,
                        Type = user.Type,
                        LocalAddress = user.LocalAddress
                    };
                    return userDto;
                }

                return new UserDto();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<LoginResponseDto> Login(LoginDto request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return (new LoginResponseDto() { 
                    AccessToken= new JwtSecurityTokenHandler().WriteToken(token),
                    FullName = user.Name + " " + user.Surname,
                    Id= user.Id,
                    UserType = user.Type,
                    Number = user.Number
                });
            }
            return new LoginResponseDto();
        }

        public async Task<bool> Register(RegisterDto request)
        {
            var userExists = await _userManager.FindByNameAsync(request.Username);
            if (userExists != null)
                return false;
            ApplicationUser user = new ApplicationUser()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Username,
                Name = request.Name,
                Surname= request.Surname,
                Number = request.Number,
                Type = request.Type
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return false;
            return true;
        }

        public async Task<bool> UpdateLocalAddress(LocalAddressRequest request)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(e => e.Id == request.UserId);
            if(user != null)
            {
                if(user.LocalAddress != null)
                {
                    if(user.LocalAddress != request.LocalAddress)
                    {
                        user.LocalAddress = request.LocalAddress;
                        var result = await _userManager.UpdateAsync(user);
                        if (!result.Succeeded)
                            return false;
                        return true;
                    }
                }
                else
                {
                    user.LocalAddress = request.LocalAddress;
                    var result = await _userManager.UpdateAsync(user);
                    if (!result.Succeeded)
                        return false;
                    return true;
                }
            }
            return true;

        }
    }
}
