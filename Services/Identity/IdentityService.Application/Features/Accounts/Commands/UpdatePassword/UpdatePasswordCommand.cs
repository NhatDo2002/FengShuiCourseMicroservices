namespace IdentityService.Application.Features.Accounts.Commands.UpdateAccount
{
    public record UpdatePasswordCommand(Guid Id, string Password) : ICommand<UpdatePasswordResult>;
    public record UpdatePasswordResult(bool IsSuccess);
}
