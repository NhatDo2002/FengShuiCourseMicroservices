namespace IdentityService.Domain.ValueObjects
{
    public class RoleName
    {
        public string Value { get; private set; } = default!;
        private RoleName(string value)
        {
            Value = value;
        }

        public static RoleName Of(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Role name cannot be null or empty.");
            }
            else if (value.Length < 3)
            {
                throw new ArgumentException("Role name must be longer than 3 characters.");
            }
            return new RoleName(value);
        }
    }
}
