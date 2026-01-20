
namespace IdentityService.Application.Features.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler(
            IApplicationDbContext dbContext
        )
        : ICommandHandler<UpdateRoleCommand, UpdateRoleResult>
    {
        public async Task<UpdateRoleResult> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
        {
            var roleId = RoleId.Of(command.Role.Id);
            var role = await dbContext.Roles.FirstOrDefaultAsync(r => r.Id == roleId, cancellationToken);
            if (role == null)
            {
                throw new NotFoundException("Role doesn't exist in system");
            }
            role.Name = RoleName.Of(command.Role.Name);
            role.Description = command.Role.Description;
            dbContext.Roles.Update(role);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new UpdateRoleResult(true);
        }
    }
}
