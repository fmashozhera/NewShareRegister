using Microsoft.EntityFrameworkCore;
using ShareRegister.Domain.Common;
using ShareRegister.Domain.IntialPublicOffer;
using System.Reflection.Metadata;

namespace ShareRegister.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Bank> Banks { get; set; }
        //public DbSet<BankBranch> BankBranches { get; set; }
        //public DbSet<BankAccount> BankAccounts { get; set; }
        //public DbSet<Broker> Brokers { get; set; }
        //public DbSet<Investor> Investors { get; set; }
        //public DbSet<Nominee> Nominees { get; set; }
        //public DbSet<TelephoneNumber> TelephoneNumbers { get; set; }
        //public DbSet<Application> Applications { get; set; }
        //public DbSet<ApplicationBatch> ApplicationBatches { get; set; }
        //public DbSet<InitialPublicOffering> InitialPublicOfferings { get; set; }
        //public DbSet<ScalingDownFactor> ScalingDownFactors { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureCommonRelations(modelBuilder);
        }

        private void ConfigureCommonRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasOne<Address>(t => t.Address);
                
        }
    }
}
