namespace IdentityService.Domain.ValueObjects
{
    public class RoleId
    {
        public Guid Value { get; private set; }
        private RoleId(Guid value)
        {
            Value = value;
        }

        public static RoleId Of(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException("RoleId cannot be empty.");
            }
            return new RoleId(value);
        }
    }
}
