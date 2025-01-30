using FundraisingAppProcessor.Models;

namespace FundraisingAppProcessor.Repositories;

/// <summary>
/// Interface for managing User entities in the repository.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Retrieves a User entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the User.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the User entity if found; otherwise, null.</returns>
    Task<User?> GetUserByIdAsync(int id);

    /// <summary>
    /// Retrieves a User entity by its username.
    /// </summary>
    /// <param name="username">The username of the User.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the User entity if found; otherwise, null.</returns>
    Task<User?> GetUserByUsernameAsync(string username);

    /// <summary>
    /// Retrieves all User entities.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of all User entities.</returns>
    Task<List<User>> GetAllUsersAsync();

    /// <summary>
    /// Adds a new User entity to the repository.
    /// </summary>
    /// <param name="user">The User entity to add.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the added User entity.</returns>
    Task<User> AddUserAsync(User user);

    /// <summary>
    /// Updates an existing User entity in the repository.
    /// </summary>
    /// <param name="user">The User entity to update.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdateUserAsync(User user);

    /// <summary>
    /// Deletes a User entity from the repository by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the User to delete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task DeleteUserAsync(int id);
}