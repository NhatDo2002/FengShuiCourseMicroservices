
namespace IdentityService.Application.Features.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler(
            IApplicationDbContext dbContext
        )
        : ICommandHandler<DeleteRoleCommand, DeleteRoleResult>
    {
        public async Task<DeleteRoleResult> Handle(DeleteRoleCommand command, CancellationToken cancellationToken)
        {
            var roleId = RoleId.Of(command.RoleId);
            var role = await dbContext.Roles.FirstOrDefaultAsync(r => r.Id == roleId, cancellationToken);
            if(role is null)
            {
                throw new NotFoundException("Role doesn't exist in system");
            }
            dbContext.Roles.Remove(role);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new DeleteRoleResult(true);
        }
    }
}
