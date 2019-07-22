using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SamuraiApp.Domain;

namespace Lab.Data.Mapping
{
    public class QuoteMap : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder
                .ToTable("Quotes")
                .HasKey(q => q.Id);
            builder
                .HasIndex(nameof(Quote.SamuraiId));
            builder
                .HasOne(q => q.Samurai)
                .WithMany(s => s.Quotes)
                .HasForeignKey(q => q.SamuraiId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .Property(q => q.Text)
                .HasMaxLength(128);
        }
    }
}