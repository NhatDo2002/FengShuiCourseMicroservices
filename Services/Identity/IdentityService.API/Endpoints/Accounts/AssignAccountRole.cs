
using IdentityService.Application.Features.Accounts.Commands.AssignAccountRole;

namespace IdentityService.API.Endpoints.Accounts
{
    public record AssignAccountRoleRequest(Guid AccountId, Guid RoleId);
    public record AssignAccountRoleResponse(bool IsSuccess);
    public class AssignAccountRole : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/accounts/roles", async (AssignAccountRoleRequest request, ISender sender) =>
            {
                //var command = new AssignAccountRoleCommand(accountId, roleId);
                var command = request.Adapt<AssignAccountRoleCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<AssignAccountRoleResponse>();

                return Results.Ok(response);
            })
            .WithDisplayName("AssignRole")
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status200OK)
            .WithSummary("Assign account role")
            .WithDescription("Assign new role to account");
        }
    }
}
