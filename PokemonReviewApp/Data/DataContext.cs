using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Pokemon> Pokemon { get; set; }
    public DbSet<PokemonOwner> PokemonOwners { get; set; }
    public DbSet<PokemonCategory> PokemonCategories { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Reviewer> Reviewers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PokemonOwner>()
            .HasKey(po => new { po.PokemonId, po.OwnerId });
        modelBuilder.Entity<PokemonOwner>()
            .HasOne(po => po.Pokemon)
            .WithMany(p => p.PokemonOwners)
            .HasForeignKey(po => po.PokemonId);
        modelBuilder.Entity<PokemonOwner>()
            .HasOne(po => po.Owner)
            .WithMany(o => o.PokemonOwners)
            .HasForeignKey(po => po.OwnerId);

        modelBuilder.Entity<PokemonCategory>()
            .HasKey(pc => new { pc.PokemonId, pc.CategoryId });
        modelBuilder.Entity<PokemonCategory>()
            .HasOne(pc => pc.Pokemon)
            .WithMany(p => p.PokemonCategories)
            .HasForeignKey(pc => pc.PokemonId);
        modelBuilder.Entity<PokemonCategory>()
            .HasOne(pc => pc.Category)
            .WithMany(c => c.PokemonCategories)
            .HasForeignKey(pc => pc.CategoryId);
    }
}