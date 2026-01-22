namespace IdentityService.Application.Features.Accounts.Queries.GetAccountRoles
{
    public record GetAccountRolesQuery(Guid AccountId) : IQuery<GetAccountRolesResult>;
    public record GetAccountRolesResult(IEnumerable<RoleDto> Roles);
}
