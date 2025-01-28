using FundraisingAppProcessor.Models;

namespace FundraisingAppProcessor.Services;

public interface IUserService
{
    Task<User> CreateUserAsync(string username, string password, UserRole role);
    Task<User?> ValidateUserAsync(string username, string password);
}