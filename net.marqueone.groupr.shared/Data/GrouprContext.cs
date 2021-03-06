using Microsoft.EntityFrameworkCore;
using net.marqueone.groupr.shared.Models;

namespace net.marqueone.groupr.shared.Data
{
    public class GrouprContext : DbContext
    {
        public GrouprContext(DbContextOptions<GrouprContext> options)
            : base(options)
        {
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMemebers { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Group>().HasMany(r => r.Members).WithOne();
        // }
    }
}