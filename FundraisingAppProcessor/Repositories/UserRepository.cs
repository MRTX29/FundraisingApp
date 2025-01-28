using FundraisingAppProcessor.Data;
using FundraisingAppProcessor.Models;
using Microsoft.EntityFrameworkCore;

namespace FundraisingAppProcessor.Repositories;

public class UserRepository(FundraisingContext context) : IUserRepository
{
    public async Task<User?> GetUserByIdAsync(int id) => await context.Users.FindAsync(id);

    public async Task<User?> GetUserByUsernameAsync(string username)
        => await context.Users.FirstOrDefaultAsync(u => u.Username == username);

    public async Task<List<User>> GetAllUsersAsync() => await context.Users.ToListAsync();

    public async Task<User> AddUserAsync(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task UpdateUserAsync(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user != null)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
    }
}