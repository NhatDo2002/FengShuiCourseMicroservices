namespace IdentityService.Application.Accounts.Queries.Login
{
    public record LoginQuery(LoginDto LoginDto) : IQuery<LoginResult>;
    public record LoginResult(bool IsSuccess);

    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(x => x.LoginDto.Username)
                .NotEmpty().WithMessage("Username is required.");
            RuleFor(x => x.LoginDto.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
