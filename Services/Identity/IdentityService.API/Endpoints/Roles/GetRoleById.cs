
using IdentityService.Application.Features.Roles.Queries.GetRoleById;

namespace IdentityService.API.Endpoints.Roles
{
    //public record GetRoleByIdRequest(Guid RoleId);
    public record GetRoleByIdResponse(RoleDto RoleDto);
    public class GetRoleById : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.Map("/roles/{roleId}", async (Guid roleId, ISender sender) =>
            {
                var query = new GetRoleByIdQuery(roleId);
                var result = await sender.Send(query);
                var response = result.Adapt<GetRoleByIdResponse>();
                return Results.Ok(response);
            })
            .WithDisplayName("GetRoleById")
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status200OK)
            .WithSummary("Get role by id")
            .WithDescription("Get role with provided id");
        }
    }
}
