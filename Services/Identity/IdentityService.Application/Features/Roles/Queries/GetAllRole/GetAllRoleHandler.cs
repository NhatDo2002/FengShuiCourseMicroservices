
namespace IdentityService.Application.Features.Roles.Queries.GetAllRole
{
    public class GetAllRoleQueryHandler(
            IApplicationDbContext dbContext
        )
        : IQueryHandler<GetAllRoleQuery, GetAllRoleResult>
    {
        public async Task<GetAllRoleResult> Handle(GetAllRoleQuery query, CancellationToken cancellationToken)
        {
            var pagination = query.PaginationRequest;
            var totalCount = await dbContext.Roles.LongCountAsync();
            var roles = await dbContext.Roles
                                       .Skip(pagination.PageIndex * pagination.PageSize)
                                       .Take(pagination.PageSize)
                                       .ToListAsync();
            var roleDtos = roles.ToRoleDtoList();
            var paginatedResult = new PaginatedResult<RoleDto>(
                    pageIndex: pagination.PageIndex,
                    pageSize: pagination.PageSize,
                    totalCount: totalCount,
                    data: roleDtos
                );
            return new GetAllRoleResult(paginatedResult);
        }
    }
}
