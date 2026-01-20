using IdentityService.Application.Features.Accounts.Commands.DeleteAccount;

namespace IdentityService.API.Endpoints.Accounts
{
    public record DeleteAccountRequest(Guid AccountId);
    public record DeleteAccountResponse(bool IsSuccess);
    public class DeleteAccount : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/accounts/{accountId}", async (Guid accountId, ISender sender) =>
            {
                var query = new DeleteAccountCommand(accountId);
                var result = await sender.Send(query);
                var response = result.Adapt<DeleteAccountResponse>();

                return Results.Ok(response);
            })
            .WithDisplayName("DeleteAccount")
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status200OK)
            .WithSummary("Delete account")
            .WithDescription("Delete account information with provided id");
        }
    }
}
