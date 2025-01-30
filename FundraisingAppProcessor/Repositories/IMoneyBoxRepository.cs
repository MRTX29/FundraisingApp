using FundraisingAppProcessor.Models;

namespace FundraisingAppProcessor.Repositories;

/// <summary>
/// Interface for managing MoneyBox entities in the repository.
/// </summary>
public interface IMoneyBoxRepository
{
    /// <summary>
    /// Retrieves a MoneyBox entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the MoneyBox.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the MoneyBox entity if found; otherwise, null.</returns>
    Task<MoneyBox?> GetMoneyBoxByIdAsync(int id);

    /// <summary>
    /// Retrieves all MoneyBox entities.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of all MoneyBox entities.</returns>
    Task<List<MoneyBox>> GetAllMoneyBoxesAsync();

    /// <summary>
    /// Adds a new MoneyBox entity to the repository.
    /// </summary>
    /// <param name="box">The MoneyBox entity to add.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the added MoneyBox entity.</returns>
    Task<MoneyBox> AddMoneyBoxAsync(MoneyBox box);

    /// <summary>
    /// Updates an existing MoneyBox entity in the repository.
    /// </summary>
    /// <param name="box">The MoneyBox entity to update.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdateMoneyBoxAsync(MoneyBox box);

    /// <summary>
    /// Deletes a MoneyBox entity from the repository by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the MoneyBox to delete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task DeleteMoneyBoxAsync(int id);
}