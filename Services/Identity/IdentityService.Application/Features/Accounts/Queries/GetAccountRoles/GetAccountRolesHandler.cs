
namespace IdentityService.Application.Features.Accounts.Queries.GetAccountRoles
{
    public class GetAccountRolesHandler : IQueryHandler<GetAccountRolesQuery, GetAccountRolesResult>
    {
        public Task<GetAccountRolesResult> Handle(GetAccountRolesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
