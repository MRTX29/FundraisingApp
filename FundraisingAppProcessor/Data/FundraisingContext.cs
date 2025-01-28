using FundraisingAppProcessor.Models;
using Microsoft.EntityFrameworkCore;

namespace FundraisingAppProcessor.Data;

public class FundraisingContext(DbContextOptions<FundraisingContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<MoneyBox> MoneyBoxes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().Property(u => u.Role).HasConversion<string>();
        modelBuilder.Entity<MoneyBox>().OwnsOne(mb => mb.Denominations);
    }
}