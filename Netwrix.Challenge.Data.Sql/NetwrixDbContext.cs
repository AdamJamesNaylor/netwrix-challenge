
namespace Netwrix.Challenge.Data.Sql {
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Models;

    public interface INetwrixDbContext {
        DbSet<Customer> Customers { get; set; }
        DbSet<Invoice> Invoices { get; set; }
        DatabaseFacade Database { get; }
        int SaveChanges();
    }

    public class NetwrixDbContext
        : DbContext, INetwrixDbContext {

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //        optionsBuilder.UseSqlServer(@"Server=HCDEVLAP212\SQLEXPRESS;Database=netwrix;Trusted_Connection=True;");
        //}

        public NetwrixDbContext(DbContextOptions<NetwrixDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Customer>(entity => {
                entity.Property(e => e.Name).HasColumnType("nvarchar(100)");
                entity.Property(e => e.Address1).HasColumnType("nvarchar(100)");
                entity.Property(e => e.Address2).HasColumnType("nvarchar(100)");
                entity.Property(e => e.Postcode).HasColumnType("nvarchar(100)");
                entity.Property(e => e.Telephone).HasColumnType("nvarchar(15)");
            });
            modelBuilder.Entity<Invoice>(entity => {
                entity.Property(e => e.CustomerId).HasColumnType("int");
                entity.Property(e => e.Ref).HasColumnType("nvarchar(10)");
                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
                entity.Property(e => e.IsPaid).HasColumnType("bit");
                entity.Property(e => e.Value).HasColumnType("decimal(8, 10)");
            });
        }
    }
}