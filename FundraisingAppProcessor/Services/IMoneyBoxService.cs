using FundraisingAppProcessor.Models;

namespace FundraisingAppProcessor.Services;

/// <summary>
/// Interface for managing MoneyBox-related operations in the service layer.
/// </summary>
public interface IMoneyBoxService
{
    /// <summary>
    /// Creates a new MoneyBox.
    /// </summary>
    /// <param name="dateReturned">The date the MoneyBox was returned.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the newly created MoneyBox entity.</returns>
    Task<MoneyBox> CreateMoneyBoxAsync(DateTime? dateReturned);

    /// <summary>
    /// Retrieves all MoneyBox entities.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of all MoneyBox entities.</returns>
    Task<List<MoneyBox>> GetAllMoneyBoxesAsync();

    /// <summary>
    /// Retrieves a MoneyBox entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the MoneyBox.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the MoneyBox entity if found; otherwise, null.</returns>
    Task<MoneyBox?> GetMoneyBoxByIdAsync(int id);

    /// <summary>
    /// Approves a MoneyBox.
    /// </summary>
    /// <param name="id">The unique identifier of the MoneyBox to approve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the approved MoneyBox entity.</returns>
    Task<MoneyBox> ApproveMoneyBoxAsync(int id);

    /// <summary>
    /// Updates a MoneyBox with new denominations.
    /// </summary>
    /// <param name="boxId">The unique identifier of the MoneyBox to update.</param>
    /// <param name="denominations">The Denominations object containing the new denominations.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated MoneyBox entity.</returns>
    Task<MoneyBox> UpdateDenominationsAsync(int boxId, Denominations denominations);
}
