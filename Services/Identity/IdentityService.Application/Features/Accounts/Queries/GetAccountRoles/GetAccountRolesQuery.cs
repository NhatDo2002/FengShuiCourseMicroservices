namespace IdentityService.Application.Features.Accounts.Queries.GetAccountRoles
{
    public record GetAccountRolesQuery(Guid RoleId) : IQuery<GetAccountRolesResult>;
    public record GetAccountRolesResult(IEnumerable<RoleDto> Roles);
}
