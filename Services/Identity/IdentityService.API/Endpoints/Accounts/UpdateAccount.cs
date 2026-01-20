using IdentityService.Application.Features.Accounts.Commands.UpdateAccount;

namespace IdentityService.API.Endpoints.Accounts
{
    public record UpdateAccountRequest(AccountDto Account);
    public record UpdateAccountResponse(bool IsSuccess);
    public class UpdateAccount : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/accounts", async (UpdateAccountRequest request, ISender sender) =>
            {
                var commannd = request.Adapt<UpdateAccountCommand>();
                var result = await sender.Send(request);
                var response = result.Adapt<UpdateAccountResult>();

                return Results.Ok(response);
            })
            .WithDisplayName("UpdateAccount")
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status200OK)
            .WithSummary("Update user information")
            .WithDescription("Update user information with provided data");
        }
    }
}
