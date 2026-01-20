namespace IdentityService.Application.Features.Accounts.Commands.Register
{
    public record RegisterCommand(RegisterDto RegisterDto) : ICommand<RegisterResult>;
    public record RegisterResult(string Username);
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.RegisterDto.Username)
                .NotEmpty().WithMessage("Username is required.");
            RuleFor(x => x.RegisterDto.Password)
                .NotEmpty().WithMessage("Password is required.");
            RuleFor(x => x.RegisterDto.Password)
                .MinimumLength(8).WithMessage("Password is equal or longer than 8 digits.");
            RuleFor(x => x.RegisterDto.FullName)
                .NotEmpty().WithMessage("FullName is required.");
            RuleFor(x => x.RegisterDto.Email)
                .NotEmpty().WithMessage("Email is required.");
            RuleFor(x => x.RegisterDto.Email)
                .EmailAddress().WithMessage("Must type an valid email.");

        }
    }
}
