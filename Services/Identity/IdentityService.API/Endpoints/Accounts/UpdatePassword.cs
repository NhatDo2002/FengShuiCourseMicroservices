
using IdentityService.Application.Features.Accounts.Commands.UpdateAccount;

namespace IdentityService.API.Endpoints.Accounts
{
    public record UpdatePassordRequest(Guid Id, string Password);
    public record UpdatePassordResponse(bool IsSuccess);

    public class UpdatePassword : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/accounts/update-password", async (UpdatePassordRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdatePasswordCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdatePassordResponse>();

                return Results.Ok(response);
            })
            .WithDisplayName("UpdatePassword")
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status200OK)
            .WithSummary("Update user password")
            .WithDescription("Update user password with provided data");
        }
    }
}
