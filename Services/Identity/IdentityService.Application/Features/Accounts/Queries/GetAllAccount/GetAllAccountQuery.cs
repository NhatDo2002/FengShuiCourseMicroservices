namespace IdentityService.Application.Features.Accounts.Queries.GetAllAccount
{
    public record GetAllAccountQuery(PaginationRequest PaginationRequest) : IQuery<GetAllAccountResult>;
    public record GetAllAccountResult(PaginatedResult<AccountDto> AccountDtos);
    public class GetAllAccountValidator : AbstractValidator<GetAllAccountQuery>
    {
        public GetAllAccountValidator()
        {
            RuleFor(x => x.PaginationRequest.PageIndex).GreaterThan(0).WithMessage("Page index must not less than 0");
            RuleFor(x => x.PaginationRequest.PageSize).GreaterThan(0).WithMessage("Page size must not less than 0");
        }
    }
}
