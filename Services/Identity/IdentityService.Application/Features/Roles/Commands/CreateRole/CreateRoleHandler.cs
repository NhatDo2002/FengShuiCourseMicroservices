
namespace IdentityService.Application.Features.Roles.Commands.CreateRole
{
    public class CreateRoleCommandHandler(
            IApplicationDbContext dbContext
        )
        : ICommandHandler<CreateRoleCommand, CreateRoleResult>
    {
        public async Task<CreateRoleResult> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
        {
            var roleId = RoleId.Of(Guid.NewGuid());
            var roleName = RoleName.Of(command.Role.Name);
            var role = Role.Create(roleId, roleName, command.Role.Description);
            await dbContext.Roles.AddAsync(role);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new CreateRoleResult(true);
        }
    }
}
