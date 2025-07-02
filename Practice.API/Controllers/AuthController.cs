using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Practice.Application.DTOs;
using Practice.Application.Jwt;

namespace Practice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtAuthentication _jwtAuthentication;

        public AuthController(UserManager<IdentityUser> userManager, JwtAuthentication jwtAuthentication)
        {
            _userManager = userManager;
            _jwtAuthentication = jwtAuthentication;
        }

        [HttpPost("Regsiter")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var user = new IdentityUser 
            { 
                UserName=registerDto.Name,
                Email=registerDto.Email,
               
            };
            var result=await _userManager.CreateAsync(user,registerDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user");
                return Ok("Register Successfully");
            }
            return BadRequest("Registeration Failed");

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user=await _userManager.FindByEmailAsync(loginDto.Email);
            if(user!=null && await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                var token = await _jwtAuthentication.GenerateToken(user);
                return Ok(token);
            }
            return Unauthorized("Invalid Credentials");
        }

    }
}
