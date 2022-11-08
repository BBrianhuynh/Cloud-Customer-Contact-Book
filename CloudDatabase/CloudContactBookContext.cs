using CloudDatabase.Tables;
using Database.Tables;
using Microsoft.EntityFrameworkCore;

namespace CloudDatabase
{
    public class CloudContactBookContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ContactInGroup> ContactInGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContactInGroup>()
                .HasKey(x => new { x.ContactId, x.GroupId });
        }

        public DbSet<Group> Groups { get; set; }
        
        public DbSet<ContactInGroup> ContactInGroups { get; set; }

        public CloudContactBookContext(DbContextOptions<CloudContactBookContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ContactInGroup>()
                .HasNoKey();
        }
    }
}