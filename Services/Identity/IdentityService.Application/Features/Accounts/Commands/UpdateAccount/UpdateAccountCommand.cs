namespace IdentityService.Application.Features.Accounts.Commands.UpdateAccount
{
    public record UpdateAccountCommand(AccountDto Account) : ICommand<UpdateAccountResult>;
    public record UpdateAccountResult(bool IsSuccess);
    public class UpdateAccountValidator : AbstractValidator<UpdateAccountCommand>
    {
        public UpdateAccountValidator() 
        {
            RuleFor(x => x.Account.Id).NotEmpty().WithMessage("Account id cannot be empty");
            RuleFor(x => x.Account.FullName).NotEmpty().WithMessage("Full name cannot be empty");
            RuleFor(x => x.Account.Email).NotEmpty().WithMessage("Email cannot be empty");
        }
    }
}
