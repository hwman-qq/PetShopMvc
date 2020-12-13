namespace PetShop.Data.SqlServer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PetShopOrdersDbContext : DbContext
    {
        public PetShopOrdersDbContext()
            : base("name=PetShopOrdersDbContext")
        {
        }

        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderStatu> OrderStatus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LineItem>()
                .Property(e => e.ItemId)
                .IsUnicode(false);

            modelBuilder.Entity<LineItem>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Order>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipAddr1)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipAddr2)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipCity)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipState)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipZip)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipCountry)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.BillAddr1)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.BillAddr2)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.BillCity)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.BillState)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.BillZip)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.BillCountry)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Courier)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.TotalPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Order>()
                .Property(e => e.BillToFirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.BillToLastName)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipToFirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipToLastName)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.CreditCard)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.ExprDate)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.CardType)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Locale)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.LineItems)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderStatus)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderStatu>()
                .Property(e => e.Status)
                .IsUnicode(false);
        }
    }
}
