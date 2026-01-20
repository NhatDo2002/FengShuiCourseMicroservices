namespace IdentityService.Application.Features.Accounts.Commands.DeleteAccount
{
    public record DeleteAccountCommand(Guid AccountId) : ICommand<DeleteAccountResult>;
    public record DeleteAccountResult(bool IsSuccess);
    public class DeleteAccountValidator : AbstractValidator<DeleteAccountCommand>
    {
        public DeleteAccountValidator() 
        { 
            RuleFor(x => x.AccountId).NotEmpty().WithMessage("Account id cannot be empty");
        }
    }
}
