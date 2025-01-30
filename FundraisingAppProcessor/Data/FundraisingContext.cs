using FundraisingAppProcessor.Models;
using Microsoft.EntityFrameworkCore;

namespace FundraisingAppProcessor.Data;

/// <summary>
/// Database context for the Fundraising application.
/// </summary>
public class FundraisingContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FundraisingContext"/> class.
    /// </summary>
    /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
    public FundraisingContext(DbContextOptions<FundraisingContext> options) : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the Users DbSet.
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Gets or sets the MoneyBoxes DbSet.
    /// </summary>
    public DbSet<MoneyBox> MoneyBoxes { get; set; }

    /// <summary>
    /// Configures the model that was discovered by convention from the entity types
    /// exposed in <see cref="DbSet{TEntity}"/> properties on your derived context.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().Property(u => u.Role).HasConversion<string>();
        modelBuilder.Entity<MoneyBox>().OwnsOne(mb => mb.Denominations);
    }
}