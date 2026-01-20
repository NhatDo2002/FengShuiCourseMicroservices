
namespace IdentityService.Application.Features.Accounts.Commands.UpdateAccount
{
    public class UpdatePasswordCommandHandler(
            IApplicationDbContext dbContext,
            IPasswordHasher passwordHasher
        )
        : ICommandHandler<UpdatePasswordCommand, UpdatePasswordResult>
    {
        public async Task<UpdatePasswordResult> Handle(UpdatePasswordCommand command, CancellationToken cancellationToken)
        {
            var accountId = AccountId.Of(command.Id);
            var account = await dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
            if (account == null) {
                throw new NotFoundException("Account doesn't exist in system");
            }
            var hashedPassword = passwordHasher.HashPassword(command.Password);
            account.UpdateAccountPassword(AccountPassword.Of(hashedPassword));
            dbContext.Accounts.Update(account);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new UpdatePasswordResult(true);
        }
    }
}
