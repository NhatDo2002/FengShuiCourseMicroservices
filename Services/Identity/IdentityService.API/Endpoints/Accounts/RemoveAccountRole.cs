
using IdentityService.Application.Features.Accounts.Commands.RemoveAccountRole;

namespace IdentityService.API.Endpoints.Accounts
{
    //public record RemoveAccountRoleRequest(Guid AccountId, Guid RoleId);
    public record RemoveAccountRoleResponse(bool IsSuccess);
    public class RemoveAccountRole : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/accounts/{accountId}/roles/{roleId}", async (Guid accountId, Guid roleId, ISender sender) =>
            {
                var command = new RemoveAccountRoleCommand(accountId, roleId);
                var result = await sender.Send(command);
                var response = result.Adapt<RemoveAccountRoleResponse>();

                return Results.Ok(response);
            })
            .WithDisplayName("RemoveRole")
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status200OK)
            .WithSummary("Remove account role")
            .WithDescription("Remove role of account");
        }
    }
}
