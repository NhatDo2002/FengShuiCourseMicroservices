
namespace IdentityService.Application.Features.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler(
            IApplicationDbContext dbContext
        )
        : ICommandHandler<DeleteAccountCommand, DeleteAccountResult>
    {
        public async Task<DeleteAccountResult> Handle(DeleteAccountCommand command, CancellationToken cancellationToken)
        {
            var accountId = AccountId.Of(command.AccountId);
            var account = await dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == accountId, cancellationToken);
            if(account is null)
            {
                throw new NotFoundException("Account doesn't exist in system");
            }
            dbContext.Accounts.Remove(account);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new DeleteAccountResult(true);
        }
    }
}
