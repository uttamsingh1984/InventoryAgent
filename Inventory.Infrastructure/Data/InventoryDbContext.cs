using Inventory.Application.Data;
using Inventory.Domain.Product;
using Microsoft.EntityFrameworkCore;
using System.ClientModel.Primitives;

public sealed class InventoryDbContext : DbContext, IApplicatonDbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) :base(options)
    {
        if (this.Products.Count() == 0)
        {
            this.Products.AddRange(
                new Product { Id = "Prod-123", Name = "Colgate 100g", Category = "Personal Care", Color = "White", Description = "This is Dabur original product", Manufacturer = "Dabur", Price = 240, Quantity = 10, CreatedAt = DateTime.UtcNow },
                new Product { Id = "Prod-124", Name = "Dettol Soap 75g", Category = "Personal Care", Color = "Green", Description = "Antibacterial bathing soap", Manufacturer = "Reckitt", Price = 45, Quantity = 25, CreatedAt = DateTime.UtcNow },
                new Product { Id = "Prod-125", Name = "Parle-G Biscuit 250g", Category = "Food", Color = "Yellow", Description = "Classic glucose biscuits", Manufacturer = "Parle", Price = 35, Quantity = 50, CreatedAt = DateTime.UtcNow },
                new Product { Id = "Prod-126", Name = "Amul Butter 500g", Category = "Dairy", Color = "Yellow", Description = "Fresh dairy butter", Manufacturer = "Amul", Price = 260, Quantity = 15, CreatedAt = DateTime.UtcNow },
                new Product { Id = "Prod-127", Name = "Tata Salt 1kg", Category = "Food", Color = "White", Description = "Iodized salt", Manufacturer = "Tata", Price = 25, Quantity = 100, CreatedAt = DateTime.UtcNow },
                new Product { Id = "Prod-128", Name = "Surf Excel 1kg", Category = "Household", Color = "Blue", Description = "Detergent powder", Manufacturer = "Unilever", Price = 180, Quantity = 20, CreatedAt = DateTime.UtcNow },
                new Product { Id = "Prod-129", Name = "Maggi Noodles 70g", Category = "Food", Color = "Yellow", Description = "Instant noodles pack", Manufacturer = "Nestle", Price = 15, Quantity = 200, CreatedAt = DateTime.UtcNow },
                new Product { Id = "Prod-130", Name = "Pepsi 1L", Category = "Beverages", Color = "Black", Description = "Carbonated soft drink", Manufacturer = "PepsiCo", Price = 60, Quantity = 30, CreatedAt = DateTime.UtcNow },
                new Product { Id = "Prod-131", Name = "Samsung Galaxy M14", Category = "Electronics", Color = "Blue", Description = "Smartphone with 6GB RAM", Manufacturer = "Samsung", Price = 14500, Quantity = 5, CreatedAt = DateTime.UtcNow },
                new Product { Id = "Prod-132", Name = "Nike Running Shoes", Category = "Footwear", Color = "Black", Description = "Comfortable sports shoes", Manufacturer = "Nike", Price = 3200, Quantity = 0, CreatedAt = DateTime.UtcNow }
            );

            this.SaveChanges();
        }

    }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(
                this.GetType().Assembly);
}