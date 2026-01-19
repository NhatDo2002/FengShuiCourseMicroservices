namespace IdentityService.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Account> Accounts { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
