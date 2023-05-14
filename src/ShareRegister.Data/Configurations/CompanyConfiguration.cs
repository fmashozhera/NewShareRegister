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
        
        builder.OwnsOne(p => p.Address, p =>
        {
            p.Property(p => p.Street).HasColumnName("Street");
            p.Property(p => p.Surburb).HasColumnName("Surburb");
            p.Property(p => p.City).HasColumnName("City");
            p.Property(p => p.Country).HasColumnName("Country");
            p.Property(p => p.PostalCode).HasColumnName("PostalCode");
        });

        builder.OwnsMany<TelephoneNumber>(t => t.TelephoneNumbers);
        builder.OwnsOne(p => p.Email, p => { p.Property(p => p.Value).HasColumnName("Email"); });

        builder.Metadata.FindNavigation(nameof(Company.Address))
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata.FindNavigation(nameof(Company.TelephoneNumbers))
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata.FindNavigation(nameof (Company.Email))
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
