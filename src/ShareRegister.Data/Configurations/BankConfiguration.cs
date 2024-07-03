using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareRegister.Domain.Common;

namespace ShareRegister.Data.Configurations;
public class BankConfiguration : IEntityTypeConfiguration<Bank>
{
    public void Configure(EntityTypeBuilder<Bank> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
        .ValueGeneratedNever();

        builder.OwnsMany(t => t.Branches)
            .ToTable("BankBranches");

        builder.OwnsOne(p => p.Address, p =>
           {
               p.Property(p => p.Street).HasColumnName("Street");
               p.Property(p => p.Surburb).HasColumnName("Surburb");
               p.Property(p => p.City).HasColumnName("City");
               p.Property(p => p.Country).HasColumnName("Country");
               p.Property(p => p.PostalCode).HasColumnName("PostalCode");
           });

        builder.OwnsMany(t => t.TelephoneNumbers)
            .ToTable("BankTelephoneNumbers");
    }
}
