namespace IdentityService.Domain.Data
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool CheckPassword(string password, string hashedPassword);
    }
}
