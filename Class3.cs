using System;

public class Class1
public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    public AppDbContext() : base("name=AppDbContext")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure one-to-many relationship between Category and Product
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithRequired(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .WillCascadeOnDelete(false);
    }
}

