namespace IdentityService.Application.Features.Accounts.Commands.RemoveAccountRole
{
    public record RemoveAccountRoleCommand(Guid AccountId, Guid RoleId) : ICommand<RemoveAccountRoleResult>;
    public record RemoveAccountRoleResult(bool IsSuccess);
}
