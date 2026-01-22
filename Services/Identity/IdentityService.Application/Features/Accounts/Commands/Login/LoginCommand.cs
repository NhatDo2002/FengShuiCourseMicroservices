namespace IdentityService.Application.Features.Accounts.Commands.Login
{
    public record LoginCommand(LoginDto LoginDto) : ICommand<LoginResult>;
    public record LoginResult(bool IsSuccess, string Token, DateTime ExpirationDateInUTC);

    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.LoginDto.Username)
                .NotEmpty().WithMessage("Username is required.");
            RuleFor(x => x.LoginDto.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
