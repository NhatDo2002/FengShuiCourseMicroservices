namespace IdentityService.Infrastructure.Services
{
    public class JwtTokenProcessor(
            IOptions<JwtOptions> jwtOption,
            IHttpContextAccessor httpContextAccessor
        )
        : IJwtTokenProcessor
    {
        public string GenerateJWTRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);

        }

        public (string jwtToken, DateTime expiredAtUtc) GenerateJWTToken(Account account)
        {
            var key = Encoding.UTF8.GetBytes(jwtOption.Value.Key);
            var signingKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256); 
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, account.Id.Value.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, account.UserInfo.Email!),
                new Claim(ClaimTypes.NameIdentifier, account.Id.Value.ToString()),
                new Claim(ClaimTypes.Name, account.UserInfo.FullName!),
            };
            var userRoles = account.Roles.Select(ar => ar.Role).ToList();
            foreach (var role in userRoles) 
            {
                claims.Append(new Claim(ClaimTypes.Role, role.Name.Value));
            }
            var expiredAt = DateTime.UtcNow.AddMinutes(jwtOption.Value.DurationInMinutes);
            var getToken = new JwtSecurityToken(
                    issuer: jwtOption.Value.Issuer,
                    audience: jwtOption.Value.Audience,
                    claims: claims,
                    expires: expiredAt,
                    signingCredentials: credentials
                );
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(getToken);

            return (jwtToken, expiredAt);
        }
    }
}
