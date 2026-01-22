
namespace IdentityService.Application.Features.Accounts.Commands.AssignAccountRole
{
    public class AssignAccountRoleCommandHandler(
            IApplicationDbContext dbContext
        )
        : ICommandHandler<AssignAccountRoleCommand, AssignAccountRoleResult>
    {
        public async Task<AssignAccountRoleResult> Handle(AssignAccountRoleCommand command, CancellationToken cancellationToken)
        {
            var roleId = RoleId.Of(command.RoleId);
            var role = await dbContext.Roles.FirstOrDefaultAsync(r => r.Id == roleId, cancellationToken);
            if (role is null) 
            {
                throw new NotFoundException("Role doesn't exist in system");
            }
            var accountId = AccountId.Of(command.AccountId);
            var account = await dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == accountId, cancellationToken);
            if (account is null) 
            {
                throw new NotFoundException("Account doesn't exist in system");
            }
            account.AssignRole(role);
            dbContext.Accounts.Update(account);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new AssignAccountRoleResult(true);
        }
    }
}
