namespace IdentityService.Application.Features.Accounts.Commands.Login
{
    public class LoginCommandHandler(
            IApplicationDbContext dbContext,
            IPasswordHasher passwordHasher,
            IJwtTokenProcessor jwtTokenProcessor,
            IAuthCookieWriter authCookieWriter
        )
        : ICommandHandler<LoginCommand, LoginResult>
    {
        public async Task<LoginResult> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var loginDto = command.LoginDto;
            var checkUsername = AccountUsername.Of(loginDto.Username);
            var user = await dbContext.Accounts.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Username == checkUsername, cancellationToken);
            if(user is null)
            {
                throw new AccountNotFoundException("Account doesn't exist. Please check again");
            }
            if (!passwordHasher.CheckPassword(loginDto.Password, user.PasswordHash.Value))
            {
                return new LoginResult(false, "", DateTime.Now);
            }
            else
            {
                await dbContext.Entry(user!)
                    .Collection(x => x.Roles)
                    .LoadAsync(cancellationToken);
                var (jwtToken, expirationDateInUTC) = jwtTokenProcessor.GenerateJWTToken(user);
                var refreshToken = jwtTokenProcessor.GenerateJWTRefreshToken();
                var refreshTokenExpirationDateInUTC = DateTime.UtcNow.AddDays(1);
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiresAtUtc = refreshTokenExpirationDateInUTC;

                await dbContext.SaveChangesAsync(cancellationToken);
                authCookieWriter.WriteAuthToken("ACCESS_TOKEN", jwtToken, expirationDateInUTC);
                authCookieWriter.WriteAuthToken("REFRESH_TOKEN", user.RefreshToken, user.RefreshTokenExpiresAtUtc);

                return new LoginResult(true, jwtToken, expirationDateInUTC);
            }
        }
    }
}
