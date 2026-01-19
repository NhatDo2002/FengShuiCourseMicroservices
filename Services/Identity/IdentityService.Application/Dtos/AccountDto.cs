namespace IdentityService.Application.Dtos
{
    public class AccountDto
    {
        public string? FullName { get; set; } = default!;
        public string? Email { get; private set; } = default!;
        public string? PhoneNumber { get; private set; } = default!;
        public string? Address { get; private set; } = default!;
        public Gender? Gender { get; private set; } = default!;
        public DateTime? DateOfBirth { get; private set; } = default!;
    }
}
