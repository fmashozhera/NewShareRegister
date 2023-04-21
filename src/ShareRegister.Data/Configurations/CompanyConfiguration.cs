using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareRegister.Domain.Common;

namespace ShareRegister.Data.Configurations;
internal class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedNever();
        builder.OwnsOne(t => t.Address);
        builder.OwnsMany<TelephoneNumber>(t => t.TelephoneNumbers);

        builder.Metadata.FindNavigation(nameof(Company.Address))
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata.FindNavigation(nameof(Company.TelephoneNumbers))
            .SetPropertyAccessMode((PropertyAccessMode)PropertyAccessMode.Field);
    }
}
