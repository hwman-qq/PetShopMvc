namespace PetShop.Data.SqlServer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PetShopDbContext : DbContext
    {
        public PetShopDbContext()
            : base("name=PetShopDbContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<BannerData> BannerDatas { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<SignOn> SignOns { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Addr1)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Addr2)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Zip)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<BannerData>()
                .Property(e => e.FavCategory)
                .IsUnicode(false);

            modelBuilder.Entity<BannerData>()
                .Property(e => e.BannerData1)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CatId)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Descn)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category1)
                .HasForeignKey(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inventory>()
                .Property(e => e.ItemId)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.ItemId)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.ProductId)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.ListPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Item>()
                .Property(e => e.UnitCost)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Item>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Attr1)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Attr2)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Attr3)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Attr4)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Attr5)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductId)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Descn)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.LangPref)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.FavCategory)
                .IsUnicode(false);

            modelBuilder.Entity<SignOn>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<SignOn>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Addr1)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Addr2)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Zip)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Items)
                .WithOptional(e => e.Supplier1)
                .HasForeignKey(e => e.Supplier);
        }
    }
}
