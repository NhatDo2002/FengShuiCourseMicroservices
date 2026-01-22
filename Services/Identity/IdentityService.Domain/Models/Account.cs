using IdentityService.Domain.ValueObjects;

namespace IdentityService.Domain.Models
{
    public class Account
        : Aggregate<AccountId>
    {
        private readonly List<AccountRole> _roles = new();
        public IReadOnlyCollection<AccountRole> Roles => _roles.AsReadOnly();
        public AccountUsername Username { get; private set; } = default!;
        public AccountPassword PasswordHash { get; private set; } = default!;
        public UserInfo UserInfo { get; private set; } = default!;
        public AccountStatus Status { get; private set; } = default!;
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiresAtUtc { get; set; }

        public static Account Create(AccountId id, AccountUsername username, AccountPassword password, UserInfo userInfo)
        {
            var account = new Account
            {
                Id = id,
                Username = username,
                PasswordHash = password,
                UserInfo = userInfo,
                Status = AccountStatus.Active
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

        public void SetStatusAccount(AccountStatus status)
        {
            Status = status;
            //AddDomainEvent(new DeactivatedAccountEvent(this));
        }

        public void AssignRole(Role role)
        {
            if(_roles.Any(ar => ar.RoleId == role.Id))
            {
                throw new InvalidOperationException("Role already assigned to the account.");
            }
            var accountRoleId = AccountRoleId.Of(Guid.NewGuid());
            var accountRole = AccountRole.Create(accountRoleId, Id, role.Id);
            _roles.Add(accountRole);
        }

        public void RemoveRole(Role role)
        {
            if (!_roles.Any(ar => ar.RoleId == role.Id))
            {
                throw new InvalidOperationException("This role isn't assigned to the account.");
            }
            _roles.RemoveAll(ar => ar.RoleId == role.Id);
        }
    }
}
