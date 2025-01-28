using FundraisingAppProcessor.Models;

namespace FundraisingAppProcessor.Repositories;

public interface IMoneyBoxRepository
{
    Task<MoneyBox?> GetMoneyBoxByIdAsync(int id);
    Task<List<MoneyBox>> GetAllMoneyBoxesAsync();
    Task<MoneyBox> AddMoneyBoxAsync(MoneyBox box);
    Task UpdateMoneyBoxAsync(MoneyBox box);
    Task DeleteMoneyBoxAsync(int id);
}