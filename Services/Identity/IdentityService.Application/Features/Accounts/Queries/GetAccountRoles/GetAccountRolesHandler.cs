
namespace IdentityService.Application.Features.Accounts.Queries.GetAccountRoles
{
    public class GetAccountRolesHandler(
            IApplicationDbContext dbContext
        )
        : IQueryHandler<GetAccountRolesQuery, GetAccountRolesResult>
    {
        public async Task<GetAccountRolesResult> Handle(GetAccountRolesQuery query, CancellationToken cancellationToken)
        {
            var accountId = AccountId.Of(query.AccountId);
            var account = await dbContext.Accounts
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync(a => a.Id == accountId, cancellationToken);
            if (account is null) 
            {
                throw new NotFoundException("Account doesn't exist in system");
            }
            var roles = await dbContext.AccountRoles
                                       .AsNoTracking()
                                       .Where(ar => ar.AccountId == account.Id)
                                       .Select(ar => ar.Role.ToRoleDto())
                                       .ToListAsync();

            return new GetAccountRolesResult(roles);
        }
    }
}
