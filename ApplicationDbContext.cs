using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TeaDistributor.Models;

namespace TeaDistributor
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<TeaBatch> TeaBatches { get; set; } = null!;
        public DbSet<TeaCustomer> TeaCustomers { get; set; } = null!;
        public DbSet<TeaInvoice> TeaInvoices { get; set; } = null!;
        public DbSet<TeaItem> TeaItems { get; set; } = null!;
        public DbSet<TeaOrder> TeaOrders { get; set; } = null!;
        public DbSet<TeaOrderDetail> TeaOrderDetails { get; set; } = null!;
        public DbSet<TeaRegion> TeaRegions { get; set; } = null!;
        public DbSet<TeaSupplier> TeaSuppliers { get; set; } = null!;
        public DbSet<TeaType> TeaTypes { get; set; } = null!;
    }
}
