namespace IdentityService.Application.Features.Roles.Commands.UpdateRole
{
    public record UpdateRoleCommand(RoleDto Role) : ICommand<UpdateRoleResult>;
    public record UpdateRoleResult(bool IsSuccess);
    public class UpdateRoleValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleValidator()
        {
            RuleFor(x => x.Role.Id).NotEmpty().WithMessage("Role id cannot be empty");
            RuleFor(x => x.Role.Name).NotEmpty().WithMessage("Role name cannot be empty");
        }
    }
}
