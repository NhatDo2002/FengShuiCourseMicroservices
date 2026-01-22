namespace IdentityService.Application.Features.Accounts.Commands.AssignAccountRole
{
    public record AssignAccountRoleCommand(Guid AccountId, Guid RoleId) : ICommand<AssignAccountRoleResult>;
    public record AssignAccountRoleResult(bool IsSuccess);

}
