using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SamuraiApp.Domain;

namespace Lab.Data.Mapping
{
    public class SamuraiBattleMap : IEntityTypeConfiguration<SamuraiBattle>
    {
        public void Configure(EntityTypeBuilder<SamuraiBattle> builder)
        {
            builder
                .ToTable("SamuraiBattles");
            builder
                .HasKey(sb => new { sb.BattleId, sb.SamuraiId });
            builder
                .HasOne(sb => sb.Battle)
                .WithMany(b => b.SamuraiBattles)
                .HasForeignKey(sb => new { sb.BattleId })
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(sb => sb.Samurai)
                .WithMany(s => s.SamuraiBattles)
                .HasForeignKey(sb => new { sb.SamuraiId })
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .Property(sb => sb.KillStreak)
                .IsRequired();
        }
    }
}