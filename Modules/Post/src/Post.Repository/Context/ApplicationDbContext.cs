using Microsoft.EntityFrameworkCore;

namespace Post.Repository.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Domain.Entities.Post> Posts { get; set; }

        public DbSet<Domain.Entities.PostOwner> PostOwners { get; set; }

        public DbSet<Domain.Entities.Comment> Comments { get; set; }

        public DbSet<Domain.Entities.CommentOwner> CommentOwners { get; set; }

        public DbSet<Domain.Entities.Thumbnail> Thumbnails { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Thumbnail>()
                .HasOne(e => e.Post)
                .WithOne(e => e.Thumbnail)
                .HasForeignKey<Domain.Entities.Thumbnail>(e => e.PostId)
                .IsRequired();

            modelBuilder.Entity<Domain.Entities.PostOwner>()
                .HasMany(e => e.Posts)
                .WithOne(e => e.Owner)
                .HasForeignKey(e => e.OwnerId)
                .IsRequired();

            modelBuilder.Entity<Domain.Entities.Tag>()
                .HasMany(e => e.Posts)
                .WithMany(e => e.Tags);

            modelBuilder.Entity<Domain.Entities.Post>()
                .HasMany(e => e.Comments)
                .WithOne(e => e.Post)
                .HasForeignKey(e => e.PostId)
                .IsRequired();

            modelBuilder.Entity<Domain.Entities.Comment>()
                .HasOne(e => e.Owner)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.OwnerId)
                .IsRequired();
        }
    }
}
