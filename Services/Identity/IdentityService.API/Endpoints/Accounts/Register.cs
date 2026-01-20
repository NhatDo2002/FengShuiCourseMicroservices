using IdentityService.Application.Features.Accounts.Commands.Register;

namespace IdentityService.API.Endpoints.Accounts
{
    public record RegisterRequest(RegisterDto RegisterDto);
    public record RegisterResponse(string Username);
    public class Register : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/register", async (RegisterRequest request, ISender sender) =>
            {
                var command = request.Adapt<RegisterCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<RegisterResponse>();
                return Results.Ok(response);
            })
            .WithDisplayName("Register")
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status409Conflict)
            .Produces(StatusCodes.Status200OK)
            .WithSummary("Register user")
            .WithDescription("Register user with username, password, full name and email");
        }
    }
}
