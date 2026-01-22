
using IdentityService.Application.Features.Accounts.Queries.GetAccountRoles;

namespace IdentityService.API.Endpoints.Accounts
{
    //public record GetAccountRolesRequest(IEnumerable<RoleDto> Roles);
    public record GetAccountRolesResponse(IEnumerable<RoleDto> Roles);
    public class GetAccountRoles : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/accounts/roles/{accountId}", async (Guid accountId, ISender sender) =>
            {
                var command = new GetAccountRolesQuery(accountId);
                var result = await sender.Send(command);
                var response = result.Adapt<GetAccountRolesResult>();

                return Results.Ok(response);
            })
            .WithDisplayName("GetAccountRoles")
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status200OK)
            .WithSummary("Get account roles")
            .WithDescription("Get all roles that account has");
        }
    }
}
