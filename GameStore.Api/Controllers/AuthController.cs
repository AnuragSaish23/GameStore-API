using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GameStore.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly GameStoreContext _context;

    public AuthController(IConfiguration configuration, GameStoreContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto loginDto)
    {
        var user = _context.Users.SingleOrDefault(u => 
            u.Username == loginDto.Username && u.Password == loginDto.Password);

        if (user == null)
        {
            return Unauthorized("Invalid username or password."); 
        }

        var token = GenerateJwtToken(user);

        return Ok(new { Token = token });
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterDto registerDto) 
    {
        var existingUser = _context.Users.SingleOrDefault(u => u.Username == registerDto.Username);
        if (existingUser != null)
        {
            return BadRequest("Username is already taken.");
        }

        var newUser = new User
        {
            Username = registerDto.Username,
            Password = registerDto.Password,
            Role = registerDto.Role 
        };

        _context.Users.Add(newUser);
        _context.SaveChanges();

        return Ok($"User '{newUser.Username}' registered successfully as a '{newUser.Role}'!");
    }



    private string GenerateJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration["Jwt:Key"]!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

