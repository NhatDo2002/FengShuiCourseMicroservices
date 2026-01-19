namespace IdentityService.Domain.ValueObjects
{
    public class AccountPassword
    {
        public string Value { get; private set; } = default!;

        private AccountPassword(string value)
        {
            Value = value;
        }

        public static AccountPassword Of(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Password cannot be null or empty.");
            }
            else if (value.Length < 8)
            {
                throw new ArgumentException("Password must longer than 8 digits.");
            }

            return new AccountPassword(value);
        }
    }
}
