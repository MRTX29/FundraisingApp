using FundraisingAppProcessor.Models;
using FundraisingAppProcessor.Repositories;

namespace FundraisingAppProcessor.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<User> CreateUserAsync(string username, string password, UserRole role)
    {
        var existing = await userRepository.GetUserByUsernameAsync(username);
        if (existing != null)
        {
            throw new Exception("User already exists.");
        }

        var newUser = new User 
        {
            Username = username,
            Password = password,
            Role = role
        };
        
        return await userRepository.AddUserAsync(newUser);
    }

    public async Task<User?> ValidateUserAsync(string username, string password)
    {
        var user = await userRepository.GetUserByUsernameAsync(username);
        if (user != null && user.Password == password)
        {
            return user;
        }
        return null;
    }
}