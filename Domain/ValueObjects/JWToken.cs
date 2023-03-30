namespace Domain.ValueObjects;

public class JWToken
{
    public string Token { get; private set; }
    public DateTime Expires { get; private set; }

    public JWToken()
    {
    }

    public JWToken(string token, DateTime expires)
    {
        Token = token;
        Expires = expires;
    }
}