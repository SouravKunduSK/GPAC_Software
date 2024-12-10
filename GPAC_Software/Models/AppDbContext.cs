using Microsoft.EntityFrameworkCore;

namespace GPAC_Software.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<CorporateCustomer> CorporateCustomers { get; set; }
        public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
        public DbSet<ProductService> ProductServices { get; set; }
        public DbSet<MeetingMinutesMaster> MeetingMinutesMasters { get; set; }
        public DbSet<MeetingMinutesDetail> MeetingMinutesDetails { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MeetingMinutesDetail>()
                .HasOne(d => d.MeetingMinutesMaster)
                .WithMany(m => m.MeetingMinutesDetails)
                .HasForeignKey(d => d.MasterId);
        }
    }

}
