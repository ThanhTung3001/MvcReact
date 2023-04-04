using Domain.ValueObjects;

namespace Applications.Common.Interface;

public interface IJwtToken
{
    public JWToken CreateToken(string username, string email,string role);
    public bool ValidationToken(string token);
    public JWToken RefreshToken(string refreshToken);
}