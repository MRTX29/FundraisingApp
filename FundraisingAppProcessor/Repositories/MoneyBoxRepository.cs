using FundraisingAppProcessor.Data;
using FundraisingAppProcessor.Models;
using Microsoft.EntityFrameworkCore;

namespace FundraisingAppProcessor.Repositories;

public class MoneyBoxRepository(FundraisingContext context) : IMoneyBoxRepository
{
    public async Task<MoneyBox?> GetMoneyBoxByIdAsync(int id) => await context.MoneyBoxes.FindAsync(id);
    
    public async Task<List<MoneyBox>> GetAllMoneyBoxesAsync() => await context.MoneyBoxes.ToListAsync();

    public async Task<MoneyBox> AddMoneyBoxAsync(MoneyBox box)
    {
        context.MoneyBoxes.Add(box);
        await context.SaveChangesAsync();
        return box;
    }

    public async Task UpdateMoneyBoxAsync(MoneyBox box)
    {
        context.MoneyBoxes.Update(box);
        await context.SaveChangesAsync();
    }

    public async Task DeleteMoneyBoxAsync(int id)
    {
        var box = await context.MoneyBoxes.FindAsync(id);
        if (box != null)
        {
            context.MoneyBoxes.Remove(box);
            await context.SaveChangesAsync();
        }
    }
}