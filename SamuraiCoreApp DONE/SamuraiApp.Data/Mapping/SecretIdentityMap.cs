using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SamuraiApp.Domain;

namespace Lab.Data.Mapping
{
    public class SecretIdentityMap : IEntityTypeConfiguration<SecretIdentity>
    {
        public void Configure(EntityTypeBuilder<SecretIdentity> builder)
        {
            builder
                .ToTable("SecretIdentites")
                .HasKey(e => e.Id);
            builder
                .HasOne(si => si.Samurai)
                .WithOne(s => s.SecretIdentity)
                .HasForeignKey<SecretIdentity>(si => si.SamuraiId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}