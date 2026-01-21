namespace IdentityService.Application.Features.Roles.Commands.DeleteRole
{
    public record DeleteRoleCommand(Guid RoleId) : ICommand<DeleteRoleResult>;
    public record DeleteRoleResult(bool IsSuccess);
    public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleValidator() 
        {
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Role id cannot be empty");
        }
    }
}
