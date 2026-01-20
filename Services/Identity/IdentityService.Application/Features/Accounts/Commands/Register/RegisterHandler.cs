

namespace IdentityService.Application.Features.Accounts.Commands.Register
{
    public class RegisterCommandHandler(
            IApplicationDbContext dbContext,
            IPasswordHasher passwordHasher
        )
        : ICommandHandler<RegisterCommand, RegisterResult>
    {
        public async Task<RegisterResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var checkUser = AccountUsername.Of(command.RegisterDto.Username);
            var existingAccount = await dbContext.Accounts.FirstOrDefaultAsync(x => x.Username == checkUser, cancellationToken);
            if(existingAccount is not null)
            {
                throw new AccountAlreadyExistsException("Account with this username already exists. Please choose a different username.");
            }
            var registerDto = command.RegisterDto;
            registerDto.Password = passwordHasher.HashPassword(registerDto.Password);
            var newAccount = registerDto.ToAccount();
            await dbContext.Accounts.AddAsync(newAccount, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new RegisterResult(newAccount.Username.Value);
        }

        
    }
}
