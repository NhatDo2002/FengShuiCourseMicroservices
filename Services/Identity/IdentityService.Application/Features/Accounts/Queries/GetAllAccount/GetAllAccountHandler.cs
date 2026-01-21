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
            var pageIndex = query.PaginationRequest.PageIndex - 1;
            var pageSize = query.PaginationRequest.PageSize;
            var totalCount =  await dbContext.Accounts.LongCountAsync(cancellationToken);
            var accounts = await dbContext.Accounts
                                          .Skip(pageIndex * pageSize)
                                          .Take(pageSize)
                                          .ToListAsync(cancellationToken);
            var accountDtos = accounts.ToListAccountDto(dbContext);
            var paginatedResult = new PaginatedResult<AccountDto>(
                    pageIndex: query.PaginationRequest.PageIndex,
                    pageSize: pageSize,
                    totalCount: totalCount,
                    data: accountDtos
                );
            return new GetAllAccountResult(paginatedResult);
        }
    }
}
