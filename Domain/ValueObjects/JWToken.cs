namespace Domain.ValueObjects;

public class JWToken
{
    public string Token { get; private set; }
    public string Expires { get; private set; }
    
    public string RefreshToken { get; private set; }

    public JWToken()
    {
    }

    public JWToken(string token, string expires,string refreshToken)
    {
        Token = token;
        Expires = expires;
    }
}