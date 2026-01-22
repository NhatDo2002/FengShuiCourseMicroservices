namespace IdentityService.Infrastructure.Data.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasConversion(
                    accountId => accountId.Value,
                    dbid => AccountId.Of(dbid)
                );

            builder.Property(a => a.Username)
                   .IsRequired()
                   .HasMaxLength(256)
                   .HasConversion(
                        username => username.Value,
                        dbUsername => AccountUsername.Of(dbUsername)
                   );
            builder.Property(a => a.PasswordHash)
                   .IsRequired()
                   .HasConversion(
                        passwordHash => passwordHash.Value,
                        dbPasswordHash => AccountPassword.Of(dbPasswordHash)
                   );
            builder.ComplexProperty(a => a.UserInfo, accountBuilder =>
            {
                accountBuilder.Property(u => u.Email).IsRequired().HasMaxLength(256);
                accountBuilder.Property(u => u.FullName).IsRequired().HasMaxLength(256);
                accountBuilder.Property(u => u.PhoneNumber).HasMaxLength(20);
                accountBuilder.Property(u => u.Address).HasMaxLength(512);
                accountBuilder.Property(u => u.DateOfBirth);
                accountBuilder.Property(u => u.Gender).HasDefaultValue(Gender.Male)
                                                      .HasConversion(
                                                         gender => gender.ToString(),
                                                         dbGender => (Gender)Enum.Parse(typeof(Gender), dbGender)
                                                      );
            });
            builder.Property(a => a.Status)
                   .HasDefaultValue(AccountStatus.Active)
                   .HasConversion(
                        status => status.ToString(),
                        dbStatus => (AccountStatus)Enum.Parse(typeof(AccountStatus), dbStatus)
                        );
            builder.HasMany<AccountRole>()
                   .WithOne()
                   .HasForeignKey(ar => ar.AccountId)
                   .OnDelete(DeleteBehavior.Cascade); //Xóa account sẽ xóa tất cả các role liên quan đến account đó
            builder.Navigation(a => a.Roles)
                   .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
