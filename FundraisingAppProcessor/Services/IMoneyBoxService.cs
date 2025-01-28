using FundraisingAppProcessor.Models;

namespace FundraisingAppProcessor.Services;

public interface IMoneyBoxService
{
    Task<MoneyBox> CreateMoneyBoxAsync(DateTime? dateReturned);
    Task<List<MoneyBox>> GetAllMoneyBoxesAsync();
    Task<MoneyBox?> GetMoneyBoxByIdAsync(int id);
    Task<MoneyBox> ApproveMoneyBoxAsync(int id);
    Task<MoneyBox> UpdateDenominationsAsync(int boxId, Denominations denominations);
}