namespace IdentityService.Application.Features.Roles.Queries.GetRoleById
{
    public record GetRoleByIdQuery(Guid RoleId) : IQuery<GetRoleByIdResult>;
    public record GetRoleByIdResult(RoleDto RoleDto);
    public class GetRoleByIdValidator : AbstractValidator<GetRoleByIdQuery>
    {
        public GetRoleByIdValidator() 
        {
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Role id cannot be empty");        
        }
    }
}
