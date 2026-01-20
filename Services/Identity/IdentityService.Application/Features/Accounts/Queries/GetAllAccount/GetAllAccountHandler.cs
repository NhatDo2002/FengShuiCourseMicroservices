using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Accounts.Queries.GetAllAccount
{
    public class GetAllAccountQueryHandler(
            IApplicationDbContext dbContext
        )
        : IQueryHandler<GetAllAccountQuery, GetAllAccountResult>
    {
        public async Task<GetAllAccountResult> Handle(GetAllAccountQuery query, CancellationToken cancellationToken)
        {
            if(query == null)
            {
                query = new GetAllAccountQuery(new PaginationRequest());
            }
            var paginationRequest = query.PaginationRequest;
            var totalCount =  await dbContext.Accounts.LongCountAsync(cancellationToken);
            var accounts = await dbContext.Accounts
                                          .Skip(paginationRequest.PageIndex * paginationRequest.PageSize)
                                          .Take(paginationRequest.PageSize)
                                          .ToListAsync(cancellationToken);
            var accountDtos = accounts.ToListAccountDto(dbContext);
            var paginatedResult = new PaginatedResult<AccountDto>(
                    pageIndex: paginationRequest.PageIndex,
                    pageSize: paginationRequest.PageSize,
                    totalCount: totalCount,
                    data: accountDtos
                );
            return new GetAllAccountResult(paginatedResult);
        }
    }
}
