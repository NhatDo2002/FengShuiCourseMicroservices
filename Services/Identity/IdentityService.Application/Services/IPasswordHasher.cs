namespace IdentityService.Application.Services
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool CheckPassword(string password, string hashedPassword);
    }
}
