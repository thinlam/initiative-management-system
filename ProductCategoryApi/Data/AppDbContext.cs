// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Category configuration
        builder.Entity<Category>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Ma).HasMaxLength(50).IsRequired();
            e.Property(x => x.Ten).HasMaxLength(255).IsRequired();
            e.Property(x => x.MoTa).HasMaxLength(1000);
            
            // Seed data
            e.HasData(
                new Category { Id = 1, Ma = "CAT001", Ten = "Điện tử" },
                new Category { Id = 2, Ma = "CAT002", Ten = "Quần áo" },
                new Category { Id = 3, Ma = "CAT003", Ten = "Sách" }
            );
        });
        
        // Product configuration
        builder.Entity<Product>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Ma).HasMaxLength(50).IsRequired();
            e.Property(x => x.Ten).HasMaxLength(255).IsRequired();
            e.Property(x => x.Gia).HasPrecision(18, 2).IsRequired();
            e.Property(x => x.MoTa).HasMaxLength(1000);
            
            // FK relationship
            e.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            
            // Index
            e.HasIndex(x => x.CategoryId);
        });
    }
}