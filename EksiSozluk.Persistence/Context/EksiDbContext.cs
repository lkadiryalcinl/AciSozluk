using EksiSozluk.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace EksiSozluk.Persistence.Context
{
    public class EksiDbContext : IdentityDbContext<User>
    {
        public EksiDbContext(DbContextOptions<EksiDbContext> options) : base(options) { }

        public DbSet<Channel> Channels { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Entry> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Channel and Title configuration
            modelBuilder.Entity<Channel>()
                .HasMany(e => e.Titles)
                .WithOne(e => e.Channel)
                .HasForeignKey(e => e.ChannelId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Title>()
              .HasOne(e => e.Channel)
              .WithMany(e => e.Titles)
              .HasForeignKey(e => e.ChannelId).OnDelete(DeleteBehavior.NoAction);
            // Channel and User configuration
            modelBuilder.Entity<User>()
                .HasMany(e => e.FollowedChannels)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Channel>()
                .HasOne(e => e.User)
                .WithMany(e => e.FollowedChannels)
                .HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.NoAction);

            //User and Entry Configuration
            modelBuilder.Entity<User>()
                .HasMany(e => e.Entries)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Entry>()
                .HasOne(e => e.User)
                .WithMany(e => e.Entries)
                .HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.NoAction);


            // User and Title Configuration
            modelBuilder.Entity<User>()
                .HasMany(e => e.FollowedTitles)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Title>()
                .HasOne(e => e.User)
                .WithMany(e => e.FollowedTitles)
                .HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.NoAction);

            //Title and Entry Configuration
            modelBuilder.Entity<Title>()
                .HasMany(e => e.Entries)
                .WithOne(e => e.Title)
                .HasForeignKey(e => e.TitleId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Entry>()
                .HasOne(e => e.Title)
                .WithMany(e => e.Entries)
                .HasForeignKey(e => e.TitleId).OnDelete(DeleteBehavior.NoAction);

            /*
                        modelBuilder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithMany(u => u.Followings)
                .UsingEntity<Dictionary<string, object>>(
                    "UserFollowers",
                    l => l.HasOne<User>().WithMany().HasForeignKey("FollowerId").OnDelete(DeleteBehavior.NoAction),
                    r => r.HasOne<User>().WithMany().HasForeignKey("FollowingId").OnDelete(DeleteBehavior.NoAction),
                    j =>
                    {
                        j.HasKey("FollowerId", "FollowingId");
                    }
                );
            */
        }
    }
}