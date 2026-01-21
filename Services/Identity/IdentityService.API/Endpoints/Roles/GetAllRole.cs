

using IdentityService.Application.Features.Roles.Queries.GetAllRole;

namespace IdentityService.API.Endpoints.Roles
{
    //public record GetAllRoleRequest(PaginationRequest Request);
    public record GetAllRoleResponse(PaginatedResult<RoleDto> Roles);
    public class GetAllRole : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/roles", async ([AsParameters] PaginationRequest request, ISender sender) =>
            {
                var query = new GetAllRoleQuery(request);
                var result = await sender.Send(query);
                var response = result.Adapt<GetAllRoleResponse>();
                return Results.Ok(response);
            })
            .WithDisplayName("GetAllRole")
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .WithSummary("Get all roles")
            .WithDescription("Get all roles with provided pagination parameters");
        }
    }
}
