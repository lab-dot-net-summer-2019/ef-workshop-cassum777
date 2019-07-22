using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SamuraiApp.Domain;

namespace Lab.Data.Mapping
{
    public class BattleMap : IEntityTypeConfiguration<Battle>
    {
        public void Configure(EntityTypeBuilder<Battle> builder)
        {
            builder
                .ToTable("Batles")
                .HasKey(b => b.Id);
            builder
                .Property(b => b.Name)
                .HasMaxLength(128);
        }
    }
}