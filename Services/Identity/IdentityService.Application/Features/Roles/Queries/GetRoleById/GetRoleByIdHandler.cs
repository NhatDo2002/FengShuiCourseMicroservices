
namespace IdentityService.Application.Features.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQueryHandler(
            IApplicationDbContext dbContext
        )
        : IQueryHandler<GetRoleByIdQuery, GetRoleByIdResult>
    {
        public async Task<GetRoleByIdResult> Handle(GetRoleByIdQuery query, CancellationToken cancellationToken)
        {
            var roleId = RoleId.Of(query.RoleId);
            var role = await dbContext.Roles.FirstOrDefaultAsync(x => x.Id == roleId, cancellationToken);
            if (role == null)
            {
                throw new NotFoundException("Role doesn't exist in system");
            }
            var roleDto = role.ToRoleDto();
            return new GetRoleByIdResult(roleDto);
        }
    }
}
