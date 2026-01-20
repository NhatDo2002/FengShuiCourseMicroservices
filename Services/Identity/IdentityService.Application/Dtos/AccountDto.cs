namespace IdentityService.Application.Dtos
{
    public class AccountDto
    {
        public Guid Id { get; set; } = default!;
        public string? FullName { get; set; } = default!;
        public string? Email { get; set; } = default!;
        public string? PhoneNumber { get; set; } = default!;
        public string? Address { get; set; } = default!;
        public Gender? Gender { get; set; } = default!;
        public DateTime? DateOfBirth { get; set; } = default!;
        public List<RoleDto> Roles { get; set; } = new List<RoleDto>();
    }
}
