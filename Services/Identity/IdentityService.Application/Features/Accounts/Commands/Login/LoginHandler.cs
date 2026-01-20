namespace IdentityService.Application.Features.Accounts.Commands.Login
{
    public class LoginQueryHandler(
            IApplicationDbContext dbContext,
            IPasswordHasher passwordHasher
        )
        : IQueryHandler<LoginQuery, LoginResult>
    {
        public async Task<LoginResult> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            var loginDto = query.LoginDto;
            var checkUsername = AccountUsername.Of(loginDto.Username);
            var user = await dbContext.Accounts.FirstOrDefaultAsync(x => x.Username == checkUsername, cancellationToken);
            if(user is null)
            {
                throw new AccountNotFoundException("Account doesn't exist. Please check again");
            }
            if (!passwordHasher.CheckPassword(loginDto.Password, user.PasswordHash.Value))
            {
                return new LoginResult(false);
            }
            else
            {
                return new LoginResult(true);
            }
        }
    }
}
