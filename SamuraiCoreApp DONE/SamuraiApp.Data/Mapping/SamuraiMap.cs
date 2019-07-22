using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SamuraiApp.Domain;

namespace Lab.Data.Mapping
{
    public class SamuraiMap : IEntityTypeConfiguration<Samurai>
    {
        public void Configure(EntityTypeBuilder<Samurai> builder)
        {
            builder
                .ToTable("Samurai")
                .HasKey(e => e.Id);
            builder
                .HasOne(s => s.Battle)
                .WithMany(b => b.Samurais)
                .HasForeignKey($"{nameof(Battle)}Id");
            builder
                .Property(s => s.Name)
                .HasMaxLength(128);

        }
    }
}