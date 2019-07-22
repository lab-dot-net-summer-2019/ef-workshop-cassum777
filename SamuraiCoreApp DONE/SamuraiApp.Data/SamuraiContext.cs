using Lab.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        #region Constructors
        public SamuraiContext() { }
        public SamuraiContext(DbContextOptions<SamuraiContext> options) : base(options) { }
        #endregion
        public virtual DbSet<Samurai> Samurai { get; set; }
        public virtual DbSet<Battle> Battles { get; set; }
        public virtual DbSet<SamuraiBattle> SamuraiBattles { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<SecretIdentity> SecretIdentities { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder
                .ApplyConfiguration(new SamuraiMap())
                .ApplyConfiguration(new SecretIdentityMap())
                .ApplyConfiguration(new QuoteMap())
                .ApplyConfiguration(new BattleMap())
                .ApplyConfiguration(new SamuraiBattleMap());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
                .UseLazyLoadingProxies()
                    .UseSqlServer("Server=DESKTOP-P5D71BE;Database=SamuraiAppDataCore;Trusted_Connection=True;");
    }
}