using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Applications.Common.Interface;
using Domain.ValueObjects;
using Duende.IdentityServer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace infrastructure.Identity;

public class IdentityJwt:IJwtToken
{
    private readonly IConfiguration _configuration;

    public IdentityJwt(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public JWToken CreateToken(string username, string email, string role)
    { 
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role,role)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "&F)J@NcQfTjWnZr4");
        var duration = int.Parse(_configuration["JWT.Duration"] ?? "2592000");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddSeconds(duration),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        var jwToken = new JWToken(tokenString, duration.ToString(), "");
        return jwToken;
    }

    public bool ValidationToken(string token)
    {
        throw new NotImplementedException();
    }

    public JWToken RefreshToken(string refreshToken)
    {
        throw new NotImplementedException();
    }
}