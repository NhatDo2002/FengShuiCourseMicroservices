
using IdentityService.Domain.ValueObjects;

namespace IdentityService.Application.Accounts.Commands.Register
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
            var newAccount = ToAccount(registerDto);
            await dbContext.Accounts.AddAsync(newAccount, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new RegisterResult(newAccount.Username.Value);
        }

        private Account ToAccount(RegisterDto registerDto)
        {
            var username = AccountUsername.Of(registerDto.Username);
            var password = AccountPassword.Of(registerDto.Password);
            var userInfo = UserInfo.Of(
                    fullName: registerDto.FullName,
                    email: registerDto.Email,
                    phoneNumber: registerDto.PhoneNumber,
                    address: registerDto.Address,
                    gender: registerDto.Gender,
                    dateOfBirth: registerDto.DateOfBirth
                );
            var accountId = AccountId.Of(Guid.NewGuid());
            var account = Account.Create(
                    id: accountId,
                    username: username,
                    password: password,
                    userInfo: userInfo
                );
            return account;
        }
    }
}
