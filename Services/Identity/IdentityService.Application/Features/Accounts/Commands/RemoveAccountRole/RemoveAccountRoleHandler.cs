namespace IdentityService.Application.Features.Accounts.Commands.RemoveAccountRole
{
    public class RemoveAccountRoleCommandHandler(
            IApplicationDbContext dbContext
        )
        : ICommandHandler<RemoveAccountRoleCommand, RemoveAccountRoleResult>
    {
        public async Task<RemoveAccountRoleResult> Handle(RemoveAccountRoleCommand command, CancellationToken cancellationToken)
        {
            var roleId = RoleId.Of(command.RoleId);
            var accountId = AccountId.Of(command.AccountId);
            var accountRole = dbContext.AccountRoles.FirstOrDefault(ar => ar.RoleId == roleId && ar.AccountId == accountId);
            if(accountRole is null)
            {
                throw new NotFoundException("This role isn't assigned to this account");
            }
            dbContext.AccountRoles.Remove(accountRole);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new RemoveAccountRoleResult(true);
        }
    }
}
