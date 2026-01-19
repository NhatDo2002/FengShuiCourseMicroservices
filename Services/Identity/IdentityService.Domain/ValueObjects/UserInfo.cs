namespace IdentityService.Domain.ValueObjects
{
    [ComplexType]
    public class UserInfo
    {
        public string? FullName { get; private set; } = default!;
        public string? Email { get; private set; } = default!;
        public string? PhoneNumber { get; private set; } = default!;
        public string? Address { get; private set; } = default!;
        public Gender? Gender { get; private set; } = default!;
        public DateTime? DateOfBirth { get; private set; } = default!;

        private UserInfo(string? fullName, string? email, string? phoneNumber, string? address, Gender? gender, DateTime? dateOfBirth)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }

        public static UserInfo Of(string? fullName, string? email, string? phoneNumber, string? address, Gender? gender, DateTime? dateOfBirth)
        {
            if(string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentNullException("Full name cannot be null or empty.", nameof(fullName));
            }
            if (string.IsNullOrWhiteSpace(email)) 
            {
                throw new ArgumentNullException("Email cannot be null or empty.", nameof(email));
            }
            if (!IsValidEmail(email))
            {
                throw new ArgumentException("Email is invalid.", nameof(email));
            }
            
            return new UserInfo(fullName, email, phoneNumber, address, gender, dateOfBirth);
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var trimmedEmail = email.Trim();
                if(trimmedEmail.EndsWith("."))
                {
                    return false; // suggest by @TK-421
                }
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch 
            {
                return false;
            }
        }
    }
}
