namespace IdentityService.Application.Features.Roles.Commands.CreateRole
{

    public record CreateRoleCommand(RoleDto Role) : ICommand<CreateRoleResult>;
    public record CreateRoleResult(bool IsSuccess);
    public class CreateRoleValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleValidator() 
        {
            RuleFor(x => x.Role.Name).NotEmpty().WithMessage("Role name cannot be empty");
        }
    }
}
