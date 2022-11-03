using CloudDatabase.Tables;
using Microsoft.EntityFrameworkCore;

namespace CloudDatabase
{
    public class CloudContactBookContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public CloudContactBookContext(DbContextOptions<CloudContactBookContext> options) : base(options)
        {
        }
    }
}