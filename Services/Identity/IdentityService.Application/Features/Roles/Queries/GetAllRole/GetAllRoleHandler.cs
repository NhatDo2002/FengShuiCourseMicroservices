
namespace IdentityService.Application.Features.Roles.Queries.GetAllRole
{
    public class GetAllRoleQueryHandler(
            IApplicationDbContext dbContext
        )
        : IQueryHandler<GetAllRoleQuery, GetAllRoleResult>
    {
        public async Task<GetAllRoleResult> Handle(GetAllRoleQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex - 1;
            var pageSize = query.PaginationRequest.PageSize;
            var totalCount = await dbContext.Roles.LongCountAsync();
            var roles = await dbContext.Roles
                                       .Skip(pageIndex * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();
            var roleDtos = roles.ToRoleDtoList();
            var paginatedResult = new PaginatedResult<RoleDto>(
                    pageIndex: query.PaginationRequest.PageIndex,
                    pageSize: pageSize,
                    totalCount: totalCount,
                    data: roleDtos
                );
            return new GetAllRoleResult(paginatedResult);
        }
    }
}
