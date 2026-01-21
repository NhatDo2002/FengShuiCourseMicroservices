
using IdentityService.Application.Features.Roles.Commands.CreateRole;

namespace IdentityService.API.Endpoints.Roles
{
    public record CreateRoleRequest(RoleDto Role);
    public record CreateRoleResponse(bool IsSuccess);
    public class CreateRole : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/roles", async (CreateRoleRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateRoleCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CreateRoleResponse>();

                return Results.Ok(response);
            })
            .WithDisplayName("CreateRole")
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .WithSummary("Create new role")
            .WithDescription("Create new role with provided data");
        }
    }
}
