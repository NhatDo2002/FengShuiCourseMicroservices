
namespace IdentityService.Infrastructure.Data.Configurations
{
    public class AccountRoleConfiguration : IEntityTypeConfiguration<AccountRole>
    {
        public void Configure(EntityTypeBuilder<AccountRole> builder)
        {
            builder.HasKey(ar => ar.Id);
            builder.Property(ar => ar.Id).HasConversion(
                    accountRoleId => accountRoleId.Value,
                    dbARId => AccountRoleId.Of(dbARId)
                );
            builder.Property(ar => ar.AccountId).HasConversion(
                    accountId => accountId.Value,
                    dbid => AccountId.Of(dbid)
                );
            builder.Property(ar => ar.RoleId).HasConversion(
                    roleId => roleId.Value,
                    dbid => RoleId.Of(dbid)
                );

            //Thiết lập mối quan hệ 1-n giữa Account và AccountRole (1 account có thể có nhiều role)
            //builder.HasOne(ar => ar.Account)
            //       .WithMany(a => a.Roles)
            //       .IsRequired()
            //       .HasForeignKey(ar => ar.AccountId);

            //Thiết lập mối quan hệ n-1 giữa AccountRole và Role (một role có thể được gán cho nhiều account)
            builder.HasOne(ar => ar.Role)
                   .WithMany()
                   .IsRequired()
                   .HasForeignKey(ar => ar.RoleId)
                   .OnDelete(DeleteBehavior.Restrict); //Ko cho xóa role nếu như có account sử dụng
        }
    }
}
