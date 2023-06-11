using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.BL.Interfaces;
using WebApp.MODELS.Data;
using WebApp.MODELS.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace WebApplicationN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoService _userInfoService;
        private readonly IConfiguration _configuration;

        public UserInfoController(IUserInfoService userInfoService, IConfiguration configuration)
        {
            _userInfoService = userInfoService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("AddUserInfo")]
        public async Task<IActionResult>
            AddUserInfo(string email, string password)
        {
            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password))
            {
                return BadRequest("Empty email or password!");
            }

            await _userInfoService.Add(email, password);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("GetUserInfo")]
        public async Task<IActionResult>
            GetUserInfo(string email, string password)
        {
            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password))
            {
                return BadRequest("Empty email or password!");
            }

            var user = await _userInfoService.GetUserInfo(email, password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration.GetSection("Jwt:Subject").Value),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("DisplayEmail", user.Email ?? string.Empty),
                    new Claim("View", "Employee"),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }

            else
            {
                return BadRequest("Invalid credentials");
            }
        }
    }
}
