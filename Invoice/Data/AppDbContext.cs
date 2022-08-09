using Invoice.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        // Setting Primary key with Fluent Api

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product_InvoiceDetails>(
                 PO =>
                 {
                     PO.HasKey(c => new { c.ProductId, c.InvoiceDetailsId });
                 });

            modelBuilder.Entity<InvoiceDetails>().Property(p => p.Price)
                        .HasColumnType("decimal(18,2)");
        }


        //Dbsets

        public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual DbSet<InvoiceHeader> InvoiceHeader { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Product_InvoiceDetails> Product_InvoiceDetails { get; set; }   

    }
}
