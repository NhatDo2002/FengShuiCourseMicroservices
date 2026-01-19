namespace IdentityService.Domain.Models
{
    public class Account
        : Aggregate<AccountId>
    {
        public AccountUsername Username { get; set; } = default!;
        public AccountPassword PasswordHash { get; set; } = default!;
        public UserInfo UserInfo { get; set; } = default!;

        public static Account Create(AccountId id, AccountUsername username, AccountPassword password, UserInfo userInfo)
        {
            var account = new Account
            {
                Id = id,
                Username = username,
                PasswordHash = password,
                UserInfo = userInfo
            };
            account.AddDomainEvent(new CreatedAccountEvent(account));
            return account;
        }

        public void UpdateUserInfo(UserInfo userInfo)
        {
            UserInfo = userInfo;
            AddDomainEvent(new UpdatedAccountUserInfoEvent(this));
        }

        public void UpdateAccountPassword(AccountPassword newPassword)
        {
            PasswordHash = newPassword;
        }

        public bool VerifyPassword(string password, IPasswordHasher passwordHasher)
        {
            return passwordHasher.CheckPassword(password, PasswordHash.Value);
        }
    }
}
