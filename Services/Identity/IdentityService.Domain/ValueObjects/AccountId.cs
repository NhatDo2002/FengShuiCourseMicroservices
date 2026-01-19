namespace IdentityService.Domain.ValueObjects
{
    [ComplexType]
    public class AccountId
    {
        public Guid Value { get; private set; }
        private AccountId(Guid value)
        {
            Value = value;
        }

        public static AccountId Of(Guid value)
        {
            return new AccountId(value);
        }
    }
}
