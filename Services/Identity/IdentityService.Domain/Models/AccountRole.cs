namespace IdentityService.Domain.Models
{
    public class AccountRole : Entity<AccountRoleId>
    {
        public AccountId AccountId { get; private set; } = default!; //Foreign Key
        public RoleId RoleId { get; private set; } = default!; //Foreign Key
        public Account Account { get; private set; } = default!;
        public Role Role { get; private set; } = default!;

        private AccountRole(AccountRoleId id, AccountId accountId, RoleId roleId)
        {
            Id = id;
            AccountId = accountId;
            RoleId = roleId;
        }

        public static AccountRole Create(AccountRoleId id, AccountId accountId, RoleId roleId)
        {
            return new AccountRole(id, accountId, roleId);
        }
    }
}
