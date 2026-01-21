
using IdentityService.Application.Features.Roles.Commands.DeleteRole;

namespace IdentityService.API.Endpoints.Roles
{
    //public record DeleteRoleRequest(Guid RoleId);
    public record DeleteRoleResponse(bool IsSuccess);
    public class DeleteRole : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/roles/{roleId}", async (Guid roleId, ISender sender) =>
            {
                var command = new DeleteRoleCommand(roleId);
                var result = await sender.Send(command);
                var response = result.Adapt<DeleteRoleResponse>();
                return Results.Ok(response);
            })
            .WithDisplayName("DeleteRole")
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status200OK)
            .WithSummary("Delete role")
            .WithDescription("Delete role with provided id");
        }
    }
}
