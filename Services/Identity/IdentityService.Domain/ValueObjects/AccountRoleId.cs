namespace IdentityService.Domain.ValueObjects
{
    public class AccountRoleId
    {
        public Guid Value { get; set; }
        private AccountRoleId(Guid value)
        {
            Value = value;
        }

        public static AccountRoleId Of(Guid value)
        {
            return new AccountRoleId(value);
        }
    }
}
