using Microsoft.EntityFrameworkCore;

namespace PostgreSQL.Models
{
    public class AccountsContext : DbContext
    {
        public AccountsContext()
        {
        }

        public AccountsContext(DbContextOptions<AccountsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Account { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("actor", "public");

                entity.HasKey(e => e.ActorId);

                entity.Property(e => e.ActorId).HasColumnName("actor_id").ValueGeneratedNever();
                entity.Property(e => e.FirstName).HasColumnName("first_name");
                entity.Property(e => e.LastName).HasColumnName("last_name");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasDefaultValueSql("clock_timestamp()");
            });
        }
    }
}