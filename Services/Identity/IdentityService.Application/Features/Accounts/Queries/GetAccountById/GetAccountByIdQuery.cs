namespace IdentityService.Application.Features.Accounts.Queries.GetAccountById
{
    public record GetAccountByIdQuery(Guid AccountId) : IQuery<GetAccountByIdResult>;
    public record GetAccountByIdResult(AccountDto AccountDto);
    public class GetAccountByIdValidator : AbstractValidator<GetAccountByIdQuery>
    {
        public GetAccountByIdValidator() 
        {
            RuleFor(x => x.AccountId).NotEmpty().WithMessage("Account id cannot be empty");
        }
    }
}
