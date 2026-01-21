
using IdentityService.Application.Features.Roles.Commands.UpdateRole;

namespace IdentityService.API.Endpoints.Roles
{
    public record UpdateRoleRequest(RoleDto Role);
    public record UpdateRoleResponse(bool IsSuccess);
    public class UpdateRole : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/roles", async (UpdateRoleRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateRoleCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateRoleResponse>();
                return Results.Ok(response);
            })
            .WithDisplayName("UpdateRole")
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status200OK)
            .WithSummary("Update role")
            .WithDescription("Update role with provided data");
        }
    }
}
