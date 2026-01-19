using IdentityService.Application.Accounts.Queries.Login;

namespace IdentityService.API.Endpoints
{
    public record LoginRequest(LoginDto LoginDto);
    public record LoginResponse(bool IsSuccess);
    public class Login : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/login", async (LoginRequest request, ISender sender) =>
            {
                var command = request.Adapt<LoginQuery>();
                var result = await sender.Send(command);
                var response = result.Adapt<LoginResponse>();

                return Results.Ok(response);
            })
            .WithDisplayName("Login")
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status200OK)
            .WithSummary("Login user")
            .WithDescription("Login user with username and password");
        }
    }
}
