using FundraisingAppProcessor.Models;

namespace FundraisingAppProcessor.Services;

/// <summary>
/// Interface for managing user-related operations in the service layer.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="username">The username of the new user.</param>
    /// <param name="password">The password of the new user.</param>
    /// <param name="role">The role of the new user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the newly created User entity.</returns>
    Task<User> CreateUserAsync(string username, string password, UserRole role);

    /// <summary>
    /// Validates if the user exists and the password is correct.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <param name="password">The password of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the User entity if validation is successful; otherwise, null.</returns>
    Task<User?> ValidateUserAsync(string username, string password);
}
