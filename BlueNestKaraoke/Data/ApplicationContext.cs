using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlueNestKaraoke.Data.Entities;

namespace BlueNestKaraoke.Data
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<QueueItem> QueueItems { get; set; }
        public DbSet<QueueItemRequestedSinger> QueueItemRequestedSingers { get; set; }
        public DbSet<FavoriteSong> FavoriteSongs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<QueueItemRequestedSinger>().HasKey(qirs => new { qirs.QueueItemId, qirs.SingerId });
            builder.Entity<QueueItemRequestedSinger>().HasOne(qirs => qirs.QueueItem).WithMany(qi => qi.RequestedSingers).HasForeignKey(qirs => qirs.QueueItemId);
            builder.Entity<QueueItemRequestedSinger>().HasOne(qirs => qirs.Singer).WithMany().HasForeignKey(qirs => qirs.SingerId);

            builder.Entity<FavoriteSong>().HasKey(fs => new { fs.UserId, fs.SongId });
            builder.Entity<FavoriteSong>().HasOne(fs => fs.User).WithMany().HasForeignKey(fs => fs.UserId);
            builder.Entity<FavoriteSong>().HasOne(fs => fs.Song).WithMany().HasForeignKey(fs => fs.SongId);
        }
    }
}