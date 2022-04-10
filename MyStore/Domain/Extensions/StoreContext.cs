using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Extensions;

namespace MyStore.Domain.Entities
{
    public partial class StoreContext
    {
        public DbSet<CustomerContact> CustomerContacts { get; set; }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerContact>().HasNoKey();
        }
    }
}
