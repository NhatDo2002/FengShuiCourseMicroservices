namespace IdentityService.Application.Features.Roles.Queries.GetAllRole
{
    public record GetAllRoleQuery(PaginationRequest PaginationRequest) : IQuery<GetAllRoleResult>;
    public record GetAllRoleResult(PaginatedResult<RoleDto> Roles);
    public class GetAllRoleValidator : AbstractValidator<GetAllRoleQuery>
    {
        public GetAllRoleValidator() 
        {
            RuleFor(x => x.PaginationRequest.PageIndex).LessThan(0).WithMessage("Page index cannot less than 0");
            RuleFor(x => x.PaginationRequest.PageSize).LessThan(0).WithMessage("Page size cannot less than 0");
        }
    }
}
