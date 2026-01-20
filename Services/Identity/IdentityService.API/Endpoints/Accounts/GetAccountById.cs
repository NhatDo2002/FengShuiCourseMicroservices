
using IdentityService.Application.Features.Accounts.Queries.GetAccountById;

namespace IdentityService.API.Endpoints.Accounts
{
    public record GetAccountByIdRequest(Guid AccountId);
    public record GetAccountByIdResponse(AccountDto AccountDto);
    public class GetAccountById : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/accounts/{accountId}", async (Guid accountId, ISender sender) =>
            {
                var query = new GetAccountByIdQuery(accountId);
                var result = await sender.Send(query);
                var response = result.Adapt<GetAccountByIdResponse>();

                return Results.Ok(response);
            })
            .WithDisplayName("GetAccountById")
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status200OK)
            .WithSummary("Get account information")
            .WithDescription("Get account information with provided id");
        }
    }
}
