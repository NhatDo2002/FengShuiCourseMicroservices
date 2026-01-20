
namespace IdentityService.Application.Features.Accounts.Queries.GetAccountById
{
    public class GetAccountByIdQueryHandler(
            IApplicationDbContext dbContext
        )
        : IQueryHandler<GetAccountByIdQuery, GetAccountByIdResult>
    {
        public async Task<GetAccountByIdResult> Handle(GetAccountByIdQuery query, CancellationToken cancellationToken)
        {
            var accountId = AccountId.Of(query.AccountId);
            var account = await dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == accountId, cancellationToken);
            if(account is null)
            {
                throw new NotFoundException("Account doesn't exist in system");
            }
            var accountDto = account.ToAccountDto(dbContext);
            return new GetAccountByIdResult(accountDto);
        }
    }
}
