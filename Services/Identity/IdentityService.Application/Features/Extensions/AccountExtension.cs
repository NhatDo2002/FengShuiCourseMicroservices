using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Extensions
{
    public static class AccountExtension
    {
        public static Account ToAccount(this RegisterDto registerDto)
        {
            var username = AccountUsername.Of(registerDto.Username);
            var password = AccountPassword.Of(registerDto.Password);
            var userInfo = UserInfo.Of(
                    fullName: registerDto.FullName,
                    email: registerDto.Email,
                    phoneNumber: registerDto.PhoneNumber,
                    address: registerDto.Address,
                    gender: registerDto.Gender,
                    dateOfBirth: registerDto.DateOfBirth
                );
            var accountId = AccountId.Of(Guid.NewGuid());
            var account = Account.Create(
                    id: accountId,
                    username: username,
                    password: password,
                    userInfo: userInfo
                );
            return account;
        }

        public static IEnumerable<AccountDto> ToListAccountDto(this IEnumerable<Account> accounts, IApplicationDbContext dbContext)
        {
            return accounts.Select(a => a.ToAccountDto(dbContext)).ToList();
        }

        private static AccountDto ToAccountDto(this Account account, IApplicationDbContext dbContext)
        {
            var accountDto = new AccountDto
            {
                Id = account.Id.Value,
                FullName = account.UserInfo.FullName,
                Email = account.UserInfo.Email,
                PhoneNumber = account.UserInfo.PhoneNumber,
                Address = account.UserInfo.Address,
                Gender = account.UserInfo.Gender,
                DateOfBirth = account.UserInfo.DateOfBirth,
                Roles = account.Roles.Select(r => new RoleDto()
                {
                    Id = r.RoleId.Value,
                    Name = dbContext.Roles.FirstOrDefault(rdb => rdb.Id == r.RoleId) != null ? dbContext.Roles.FirstOrDefault(rdb => rdb.Id == r.RoleId)!.Name.Value : "",
                    Description = dbContext.Roles.FirstOrDefault(rdb => rdb.Id == r.RoleId) != null ? dbContext.Roles.FirstOrDefault(rdb => rdb.Id == r.RoleId)!.Description : ""
                }).ToList()
            };

            return accountDto;
        }
    }
}
