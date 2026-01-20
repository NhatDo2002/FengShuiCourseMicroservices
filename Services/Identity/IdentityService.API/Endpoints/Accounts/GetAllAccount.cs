using IdentityService.Application.Features.Accounts.Queries.GetAllAccount;

namespace IdentityService.API.Endpoints.Accounts
{
    public record GetAllAccountRequest(PaginationRequest PaginationRequest);
    public record GetAllAccountResponse(PaginatedResult<AccountDto> AccountDtos);
    public class GetAllAccount : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/accounts?pageIndex={pageIndex}&pageSize={pageSize}", async (int pageIndex, int pageSize, ISender sender) =>
            {
                var query = new GetAllAccountQuery(new PaginationRequest(pageIndex, pageSize));
                var result = await sender.Send(query);
                var response = result.Adapt<GetAllAccountResponse>();

                return Results.Ok(response);
            })
            .WithDisplayName("GetAllAccount")
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .WithSummary("Get all accounts")
            .WithDescription("Get all accounts information with provided pagination parameters"); ;
        }
    }
}
