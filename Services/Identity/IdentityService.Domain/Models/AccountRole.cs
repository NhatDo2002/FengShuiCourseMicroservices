namespace IdentityService.Domain.Models
{
    public class AccountRole : Entity
    {
        public AccountId AccountId { get; private set; } = default!; //Foreign Key
        public RoleId RoleId { get; private set; } = default!; //Foreign Key
        public Account Account { get; private set; } = default!;
        public Role Role { get; private set; } = default!;

        private AccountRole(AccountId accountId, RoleId roleId)
        {
            AccountId = accountId;
            RoleId = roleId;
        }

        public static AccountRole Create(AccountId accountId, RoleId roleId)
        {
            return new AccountRole(accountId, roleId);
        }
    }
}
