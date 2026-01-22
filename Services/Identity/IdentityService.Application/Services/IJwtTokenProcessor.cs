namespace IdentityService.Application.Services
{
    public interface IJwtTokenProcessor
    {
        (string jwtToken, DateTime expiredAtUtc) GenerateJWTToken(Account account);
        string GenerateJWTRefreshToken();
        
    }
}
