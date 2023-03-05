using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Shop.Models
{
    public partial class PhTechContext : DbContext
    {
        public PhTechContext()
        {
        }

        public PhTechContext(DbContextOptions<PhTechContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserActivation> UserActivations { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<WarehouseDetail> WarehouseDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brands");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Tilte)
                    .HasMaxLength(255)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Colors");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Credential>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.PermissionId)
                    .HasMaxLength(50)
                    .HasColumnName("PermissionID");
                entity.Property(e => e.RoleId)
                    .HasMaxLength(50)
                    .HasColumnName("RoleID");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.Credentials)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK_Credentials_Permission");
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Credentials)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Credentials_Role");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");
                entity.Property(e => e.Note)
                    .HasMaxLength(200)
                    .HasColumnName("note");
                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("order_id");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.TotalPrice).HasColumnName("total_price");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.VoucherId).HasColumnName("voucher_id");
                entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");
                entity.Property(e => e.PaymentStatus).HasColumnName("payment_status");
                entity.Property(e => e.PaymentDetail).HasColumnName("payment_detail");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_user");
                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.VoucherId)
                    .HasConstraintName("FK_order_voucher");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetails");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_order_detalis_order");
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_order_detalis_product");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permissions");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.OutPrice).HasColumnName("out_price");
                entity.Property(e => e.ProductBrand).HasColumnName("product_brand");
                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("product_code");
                entity.Property(e => e.ProductColor).HasColumnName("product_color");
                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasColumnName("product_description");
                entity.Property(e => e.ProductImage)
                    .IsRequired()
                    .HasColumnName("product_image");
                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");
                entity.Property(e => e.ProductSize).HasColumnName("product_size");
                entity.Property(e => e.ProductSpec).HasColumnName("product_spec");
                entity.Property(e => e.ProductType).HasColumnName("product_type");
                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.ProductBrandNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductBrand)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_brand");

                entity.HasOne(d => d.ProductColorNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductColor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_Color");

                entity.HasOne(d => d.ProductSizeNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductSize)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_Size");

                entity.HasOne(d => d.ProductTypeNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_type");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Sizes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Types");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Tilte)
                    .HasMaxLength(255)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("fullname");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .HasColumnName("phone");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("RoleID");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_role");
            });

            modelBuilder.Entity<UserActivation>(entity =>
            {
                entity.ToTable("UserActivations");
                entity.HasKey(a => a.UserId);
                entity.Property(a => a.UserId).HasColumnName("user_id");
                entity.Property(a => a.Code).HasColumnName("code");
                entity.Property(a => a.ExpiredAt).HasColumnName("expired_at");
                entity.Property(a => a.Status).HasColumnName("status");

            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.ToTable("Vouchers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("date")
                    .HasColumnName("create_at");

                entity.Property(e => e.DeleteAt)
                    .HasColumnType("date")
                    .HasColumnName("delete_at");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.VoucherCode)
                    .HasMaxLength(255)
                    .HasColumnName("voucher_code");

                entity.Property(e => e.VoucherDescription)
                    .HasMaxLength(255)
                    .HasColumnName("voucher_description");

                entity.Property(e => e.VoucherDiscount).HasColumnName("voucher_discount");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateIn)
                    .HasColumnType("datetime")
                    .HasColumnName("date_in");

                entity.Property(e => e.ImportCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("import_code");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_warehouse_user");
            });

            modelBuilder.Entity<WarehouseDetail>(entity =>
            {
                entity.ToTable("WarehouseDetails");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateIn)
                    .HasColumnType("date")
                    .HasColumnName("date_in");

                entity.Property(e => e.InPrice).HasColumnName("in_price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.WarehouseDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_warehouse_detail_product");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WarehouseDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_warehouse_detail_user");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
