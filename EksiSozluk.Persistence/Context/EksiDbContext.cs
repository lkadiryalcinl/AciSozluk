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
                .HasForeignKey(e => e.ChannelId)
                .IsRequired();

            modelBuilder.Entity<Title>()
              .HasOne(e => e.Channel)
              .WithMany(e => e.Titles)
              .HasForeignKey(e => e.ChannelId)
              .IsRequired();
            //User and Entry Configuration
            modelBuilder.Entity<User>()
                .HasMany(e => e.Entries)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            modelBuilder.Entity<Entry>()
                .HasOne(e => e.User)
                .WithMany(e => e.Entries)
                .HasForeignKey(e => e.UserId)
                .IsRequired();
            //Title and Entry Configuration
            modelBuilder.Entity<Title>()
                .HasMany(e => e.Entries)
                .WithOne(e => e.Title)
                .HasForeignKey(e => e.TitleId)
                .IsRequired();

            modelBuilder.Entity<Entry>()
                .HasOne(e => e.Title)
                .WithMany(e => e.Entries)
                .HasForeignKey(e => e.TitleId)
                .IsRequired();


            modelBuilder.Entity<User>()
    .HasMany(u => u.Followers)
    .WithMany(u => u.Followings)
    .UsingEntity<Dictionary<string, object>>(
        "UserFollowers",
        l => l.HasOne<User>().WithMany().HasForeignKey("FollowerId"),
        r => r.HasOne<User>().WithMany().HasForeignKey("FollowingId"),
        j =>
        {
            j.HasKey("FollowerId", "FollowingId");
        }
    );


            modelBuilder.Entity<IdentityUserLogin<string>>()
     .HasKey(e => e.UserId);


        }
    }
}