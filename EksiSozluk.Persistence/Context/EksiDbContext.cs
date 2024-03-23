using EksiSozluk.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk.Persistence.Context
{
    public class EksiDbContext : IdentityDbContext<User>
    {
        public EksiDbContext(DbContextOptions<EksiDbContext> options) : base(options) { }

        public DbSet<Channel> Channels { get; set; }
        public DbSet<FollowChannel> FollowChannels { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<FollowTitle> FollowTitles { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<EntryTransaction> EntryTransactions { get; set; }
        public DbSet<EntryTransactionRelation> EntryTransactionRelations { get; set; }

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

            // Follow Channel and Cahnnel configuration 

            modelBuilder.Entity<FollowChannel>()
                .HasOne(e => e.Channel)
                .WithOne(e => e.FollowChannel)
                .HasForeignKey<FollowChannel>(e => e.ChannelId)
                .IsRequired();

            modelBuilder.Entity<Channel>()
                .HasOne(e => e.FollowChannel)
                .WithOne(e => e.Channel)
                .HasForeignKey<FollowChannel>(e => e.ChannelId)
                .IsRequired();

            // Follow Channel and User configuration

            modelBuilder.Entity<User>()
                .HasMany(e => e.FollowChannels)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FollowChannel>()
                .HasOne(e => e.User)
                .WithMany(e => e.FollowChannels)
                .HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.NoAction);

            //**********************

            // User and User Entries Configuration
            modelBuilder.Entity<User>()
                .HasMany(c => c.UserEntries)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Entry>()
                .HasOne(c => c.User)
                .WithMany(c => c.UserEntries)
                .HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.NoAction);
            // User and Title Configuration
            
            //Title and Entry Configuration
            modelBuilder.Entity<Title>()
                .HasMany(e => e.Entries)
                .WithOne(e => e.Title)
                .HasForeignKey(e => e.TitleId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Entry>()
                .HasOne(e => e.Title)
                .WithMany(e => e.Entries)
                .HasForeignKey(e => e.TitleId).OnDelete(DeleteBehavior.NoAction);

            //Follow Title -> Title configuration

            modelBuilder.Entity<FollowTitle>()
                .HasOne(e => e.Title)
                .WithOne(e => e.FollowTitle)
                .HasForeignKey<FollowTitle>(e => e.TitleId)
                .IsRequired();

            modelBuilder.Entity<Title>()
                .HasOne(e => e.FollowTitle)
                .WithOne(e => e.Title)
                .HasForeignKey<FollowTitle>(e => e.TitleId)
                .IsRequired();

            //Follow Title <<- User configuration
            modelBuilder.Entity<User>()
                .HasMany(e => e.FollowTitles)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<FollowTitle>()
                .HasOne(e => e.User)
                .WithMany(e => e.FollowTitles)
                .HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.NoAction);

            //Entry ->> EntryTransactionRelation
            modelBuilder.Entity<Entry>()
                .HasMany(e => e.EntryTransactionRelations)
                .WithOne(e => e.Entry)
                .HasForeignKey(e => e.EntryId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EntryTransactionRelation>()
                .HasOne(e => e.Entry)
                .WithMany(e => e.EntryTransactionRelations)
                .HasForeignKey(e => e.EntryId).OnDelete(DeleteBehavior.NoAction);

            //EntryTransaction -> EntryTransactionRelation

            modelBuilder.Entity<EntryTransactionRelation>()
                .HasOne(e => e.EntryTransaction)
                .WithOne(e => e.EntryTransactionRelation)
                .HasForeignKey<EntryTransactionRelation>(e => e.EntryTransactionId)
                .IsRequired();

            modelBuilder.Entity<EntryTransaction>()
                .HasOne(e => e.EntryTransactionRelation)
                .WithOne(e => e.EntryTransaction)
                .HasForeignKey<EntryTransactionRelation>(e => e.EntryTransactionId)
                .IsRequired();

            //User -> EntryTransactionRelation
            modelBuilder.Entity<EntryTransactionRelation>()
                .HasOne(e => e.User)
                .WithOne(e => e.EntryTransactionRelation)
                .HasForeignKey<EntryTransactionRelation>(e => e.UserId);

            modelBuilder.Entity<User>()
                .HasOne(e => e.EntryTransactionRelation)
                .WithOne(e => e.User)
                .HasForeignKey<EntryTransactionRelation>(e => e.UserId);

            // There is UserUser table on the sql now.
            // This table automatically created by the entity framework
            // We do not write any model configuration for UserUser table.
            // This table represent following and followers Id
        }
    }
}