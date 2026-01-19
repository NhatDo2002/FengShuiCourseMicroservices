namespace IdentityService.Domain.ValueObjects
{
    public class AccountUsername
    {
        public string Value { get; private set; } = default!;
        private AccountUsername(string value)
        {
            Value = value;
        }

        public static AccountUsername Of(string value) 
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Username cannot be null or empty.");
            }
            value = value.Trim();
            if (value.StartsWith(".") || value.EndsWith("."))
            {
                throw new ArgumentException("Username cannot start or end with a dot.");
            }
            return new AccountUsername(value);
        }
    }
}
