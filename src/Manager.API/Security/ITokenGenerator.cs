namespace Manager.API.Security
{
    public interface ITokenGenerator
    {
        string GenerateToken();
    }
}